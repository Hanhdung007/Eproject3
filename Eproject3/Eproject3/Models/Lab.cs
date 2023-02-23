using System;
using System.Collections.Generic;

namespace Eproject3.Models
{
    public partial class Lab
    {
        public Lab()
        {
            Devices = new HashSet<Device>();
        }

        public int LabsId { get; set; }
        public string? LabsName { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
