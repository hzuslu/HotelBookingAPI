using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.EntityLayer.Concrete
{
    public class Subscribe
    {
        public int SubscribeId { get; set; }

        public required string SubscribeMail { get; set; }
    }
}