using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationSystem.Domain.Habitaciones;

namespace HotelReservationSystem.Infrastructure.Repositories
{
    internal sealed class HabitacionRepository : Repository<Habitacion, HabitacionId>, IHabitacionRepository
    {
        public HabitacionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }        
    }
}
