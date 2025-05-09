using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationSystem.Domain.Abstractions;

namespace HotelReservationSystem.Domain.Reviews
{
    public static class ReviewErrors
    {
        public static readonly Error NotEligible = new(
           "Review.NotEligible",
           "Este review y calificacion para la habitación no es elegible por que aun no se completa"
        );
    }
}
