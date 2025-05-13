using HotelReservationSystem.Application.Abstractions.Email;
using HotelReservationSystem.Domain.Reservas;
using HotelReservationSystem.Domain.Reservas.Event;
using HotelReservationSystem.Domain.Users;
using MediatR;

namespace HotelReservationSystem.Application.Reservas.ReservaHabitacion
{
    internal sealed class ReservarHabitacionDomainEventHandler :
        INotificationHandler<HabitacionReservadaDomainEvent>
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public ReservarHabitacionDomainEventHandler(
            IReservaRepository reservaRepository,
            IUserRepository userRepository,
            IEmailService emailService)
        {
            _reservaRepository = reservaRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task Handle(
            HabitacionReservadaDomainEvent notification,
            CancellationToken cancellationToken)
        {
            var reservar = await _reservaRepository.GetByIdAsync(notification.ReservaId, cancellationToken);
            
            if(reservar is null)
            {
                return;
            }

            var user = await _userRepository.GetByIdAsync(reservar.UserId!, cancellationToken);

            if (user is null)
            {
                return;
            }

            await _emailService.SendAsync(
                user.Email!,
                "ALquiler Reservado",
                "Tienes que confirmar esta reserva de lo contrario se va a perder"
            );

        }
    }
}
