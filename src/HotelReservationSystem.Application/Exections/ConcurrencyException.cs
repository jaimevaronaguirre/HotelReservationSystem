using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Application.Exections
{
    public sealed class ConcurrencyException : Exception
    {
        public ConcurrencyException(
        string message,
        Exception innerException
        ): base( message, innerException )
        {
        }
    }
}
