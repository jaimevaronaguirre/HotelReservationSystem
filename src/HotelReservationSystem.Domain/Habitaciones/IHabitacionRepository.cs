using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Domain.Habitaciones
{
    public interface IHabitacionRepository
    {
        Task<Habitacion?> GetByIdAsync(HabitacionId id, CancellationToken cancellationToken = default);
    }
}
