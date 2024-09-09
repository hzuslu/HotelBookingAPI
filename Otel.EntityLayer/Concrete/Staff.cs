using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.EntityLayer.Concrete
{
    public class Staff
    {
        public int StaffId { get; set; }
        public required string Name { get; set; }
        public required string Title { get; set; }
        public required string Link1 { get; set; }
        public required string Link2 { get; set; }
        public required string Link3 { get; set; }

    }
}