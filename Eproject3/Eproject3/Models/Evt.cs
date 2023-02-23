using System;
using System.Collections.Generic;

namespace Eproject3.Models
{
    public partial class Evt
    {
        public int ReportId { get; set; }
        public string? Title { get; set; }
        public string Minititle { get; set; } = null!;
        public int Img { get; set; }
        public string Content { get; set; } = null!;
        public DateTime EventDate { get; set; }
        public int CalenId { get; set; }

        public virtual Calender Calen { get; set; } = null!;
    }
}
