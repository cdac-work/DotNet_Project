using System;
using System.Collections.Generic;

namespace rashi_try.Models;

public partial class Bus
{
    public int BusId { get; set; }

    public int BusNumber { get; set; }

    public int Capacity { get; set; }

    public string BusType { get; set; } = null!;

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
