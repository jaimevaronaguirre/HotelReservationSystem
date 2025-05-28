using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace HotelReservationSystem.Application.Users.RegisterUser
{
    internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(c => c.Nombre).NotEmpty().WithMessage("El nombre no puede ser nulo");
            RuleFor(c => c.Apellidos).NotEmpty().WithMessage("Los apellidos no pueden ser nulos");
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Password).NotEmpty().MinimumLength(5);
        }
    }
}
