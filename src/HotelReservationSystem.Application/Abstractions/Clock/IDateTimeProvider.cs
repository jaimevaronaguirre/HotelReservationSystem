﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Application.Abstractions.Clock
{
    public interface IDateTimeProvider
    {
        DateTime currentTime { get; }
    }
}
