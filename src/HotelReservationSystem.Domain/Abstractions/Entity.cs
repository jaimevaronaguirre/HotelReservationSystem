using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Domain.Abstractions
{
    public abstract class Entity<TEntityId> : IEntity
    {
        protected Entity()
        {

        }
        protected readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
       
        protected Entity(TEntityId id)
        {
            Id = id;
        }
        public TEntityId? Id { get; init; }
        
        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
