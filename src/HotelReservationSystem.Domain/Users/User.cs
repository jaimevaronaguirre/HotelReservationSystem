using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationSystem.Domain.Abstractions;
using HotelReservationSystem.Domain.Users.Events;

namespace HotelReservationSystem.Domain.Users
{
    public sealed class User : Entity<UserId>
    {
        private User()
        {

        }

        private User(
            UserId id,
            Nombre nombre,
            Apellido apellido,
            Email email,
            PasswordHash passwordHash
            )
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            PasswordHash = passwordHash;
        }

        public Nombre? Nombre { get; private set; }
        public Apellido? Apellido { get; private set; }
        public Email? Email { get; private set; }
        public PasswordHash? PasswordHash { get; private set; }

        public static User Create(
            Nombre nombre,
            Apellido apellido,
            Email email,
            PasswordHash passwordHash
            )
            {
            var user = new User(UserId.New(), nombre, apellido, email, passwordHash);
            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id!));
            //user._
            return user;
            }
        //public IReadOnlyCollection<Role>? Roles => _roles.ToList();

    }
}
