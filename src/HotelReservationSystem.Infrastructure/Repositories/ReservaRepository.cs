using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationSystem.Domain.Habitaciones;
using HotelReservationSystem.Domain.Reservas;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Infrastructure.Repositories
{
    internal sealed class ReservaRepository : Repository<Reserva, ReservaId>, IReservaRepository
    {

        private static readonly ReservaStatus[] ActiveAlquilerStatuses = {
        ReservaStatus.Reservado,
        ReservaStatus.Confirmado,
        ReservaStatus.Completado
    };
        public ReservaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsOverlappingAsync(
            Habitacion habitacion,
            DateRange duracion,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<Reserva>()
                .AnyAsync(
                    reserva =>
                        reserva.HabitacionId == habitacion.Id &&
                        reserva.Duracion!.Inicio <= duracion.Fin &&
                        reserva.Duracion.Fin >= duracion.Inicio &&
                        ActiveAlquilerStatuses.Contains(reserva.Status),
                        cancellationToken
                );
        }
    }
}
