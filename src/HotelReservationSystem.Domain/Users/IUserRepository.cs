﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Domain.Users
{
    public interface IUserRepository
    {

        Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);
        void Add(User user);
        Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
        Task<bool> IsUserExists(Email email, CancellationToken cancellationToken = default);


    }
}
