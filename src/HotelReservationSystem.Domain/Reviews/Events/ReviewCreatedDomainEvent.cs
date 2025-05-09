using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationSystem.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Reviews.Events
{
    public sealed record ReviewCreatedDomainEvent(ReviewId ReviewId) : IDomainEvent;
    
}
