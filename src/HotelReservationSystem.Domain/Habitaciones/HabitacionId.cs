using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Domain.Habitaciones
{
    public record HabitacionId(Guid Value)
    {
        public static HabitacionId New() => new(Guid.NewGuid());        
    }    
}
