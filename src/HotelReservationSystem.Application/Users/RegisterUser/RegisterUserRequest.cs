using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Application.Users.RegisterUser
{
    public record class RegisterUserRequest(string Email, string Nombre, string Apellidos, string Password);
    
}
