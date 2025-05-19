using HotelReservationSystem.Application.Exections;
using HotelReservationSystem.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;

        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default
            )
        {
            try
            {
                var result = await base.SaveChangesAsync(cancellationToken);
                await PublishDomainEventsAsync();
                return result;
            }
            // Captura errores de concurrencia cuando varios procesos modifican los mismos datos.
            // Lanza una excepción personalizada para manejar el conflicto.
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("La exception por concurrecia se disparo", ex);
            }
        }

        private async Task PublishDomainEventsAsync()
        {
            var domainEvents = ChangeTracker
                .Entries<IEntity>()
                .Select(entity => entity.Entity)
                .SelectMany(entity =>
                {
                    var domainEvens = entity.GetDomainEvents();
                    entity.ClearDomainEvents();
                    return domainEvens;
                }).ToList();
            foreach(var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }
        }
    }

    
}
