using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservationSystem.Application.Abstractions.Messaging;

namespace HotelReservationSystem.Application.Reservas.GetReservar
{
    public sealed record GetReservarQuery(Guid ReservaId) : IQuery<ReservarResponse>;

}
