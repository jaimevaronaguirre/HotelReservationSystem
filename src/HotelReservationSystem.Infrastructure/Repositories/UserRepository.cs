using HotelReservationSystem.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<User, UserId>, IUserRepository
    {
       public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
       {
       }

        public async Task<User?> GetByEmailAsync(Domain.Users.Email email, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<User>()
             .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }

        public async Task<bool> IsUserExists(
            Domain.Users.Email email,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<User>()
              .AnyAsync(x => x.Email == email);
        }

        //public override void Add(User user)
        //{
        //    foreach (var role in user.)
        //}
    }
}
