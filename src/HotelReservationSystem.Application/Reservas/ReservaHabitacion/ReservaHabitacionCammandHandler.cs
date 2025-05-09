using CleanArchitecture.Domain.Abstractions;
using HotelReservationSystem.Application.Abstractions.Clock;
using HotelReservationSystem.Application.Abstractions.Messaging;
using HotelReservationSystem.Application.Exections;
using HotelReservationSystem.Domain.Abstractions;
using HotelReservationSystem.Domain.Habitaciones;
using HotelReservationSystem.Domain.Reservas;
using HotelReservationSystem.Domain.Users;

namespace HotelReservationSystem.Application.Reservas.ReservaHabitacion
{
    public sealed class ReservaHabitacionCammandHandler :
        ICommandHandler<ReservaHabitacionCammand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHabitacionRepository _habitacionRepository;
        private readonly IReservaRepository _reservaRepository;
        private readonly PrecioService _precioService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ReservaHabitacionCammandHandler(
            IUserRepository userRepository,
            IHabitacionRepository habitacionRepository,
            IReservaRepository reservaRepository,
            PrecioService precioService,
            IUnitOfWork unitOfWork,
            IDateTimeProvider dateTimeProvider
            )
        {
            _userRepository = userRepository;
            _habitacionRepository = habitacionRepository;
            _reservaRepository = reservaRepository;
            _precioService = precioService;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;

        }

        public async Task<Result<Guid>> Handle(
            ReservaHabitacionCammand request,
            CancellationToken cancellationToken
            )
        {
            var userId = new UserId( request.UserId );
            var user = await _userRepository.GetByIdAsync( userId, cancellationToken );

            if (user is null)
            {
                return Result.Failure<Guid>(UserErrors.NotFound);
            }
            var habitacionId = new HabitacionId(request.HabitacionId);
            var habitacion = await _habitacionRepository.GetByIdAsync(habitacionId, cancellationToken );
            
            if (habitacion is null)
            {
                return Result.Failure<Guid>(HabitacionErrors.NotFound);
            }

            var duracion = DateRange.Create(request.FechaInicio, request.FechaFin);

            if (await _reservaRepository.IsOverlappingAsync(habitacion, duracion, cancellationToken))
            {
                return Result.Failure<Guid>(ReservaErrors.Overlap);
            }

            try
            {
                var reserva = Reserva.Alojamiento(
                    habitacion,
                    user.Id!,
                    duracion,
                    _dateTimeProvider.currentTime,
                    _precioService
                );
                _reservaRepository.Add( reserva );

                await _unitOfWork.SaveChangesAsync( cancellationToken );

                return reserva.Id!.Value;
            }
            catch(ConcurrencyException)
            {
                return Result.Failure<Guid>(ReservaErrors.Overlap);
            }
        }
    }
}
