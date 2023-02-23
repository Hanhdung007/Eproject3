using System;
using System.Collections.Generic;

namespace Eproject3.Models
{
    public partial class Calender
    {
        public Calender()
        {
            Evts = new HashSet<Evt>();
        }

        public int CalenId { get; set; }
        public string Event { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual ICollection<Evt> Evts { get; set; }
    }
}
