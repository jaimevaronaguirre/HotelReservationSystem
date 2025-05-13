using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace HotelReservationSystem.Application.Reservas.ReservaHabitacion
{
    public class ReservarAlquilerCommandValidator : AbstractValidator<ReservaHabitacionCammand>
    {
        public ReservarAlquilerCommandValidator() 
        {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.HabitacionId).NotEmpty();
            RuleFor(c => c.FechaInicio).LessThan(c => c.FechaFin);
        }
    }
}
