using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationSystem.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Reservas.Event
{
    public sealed record ReservaCompletadaDomainEvent(ReservaId Id) : IDomainEvent;
    
}
