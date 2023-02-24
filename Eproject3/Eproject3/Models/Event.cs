using System;
using System.Collections.Generic;

namespace Eproject3.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int LabsId { get; set; }

        public virtual Lab Labs { get; set; } = null!;
    }
}
