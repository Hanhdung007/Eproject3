using System;
using System.Collections.Generic;

namespace Eproject3.Models
{
    public partial class Calender
    {
        public int CalenId { get; set; }
        public string EventTitle { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int EventId { get; set; }

        public virtual Evt Event { get; set; } = null!;
    }
}
