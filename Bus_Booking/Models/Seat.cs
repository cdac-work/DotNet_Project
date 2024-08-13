using System;
using System.Collections.Generic;

namespace rashi_try.Models;

public partial class Seat
{
    public int SeatId { get; set; }

    public int BusId { get; set; }

    public int SeatNumber { get; set; }

    public bool IsAvailable { get; set; }

    public virtual Bus Bus { get; set; } = null!;
}
