using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOMO.Common
{
    public class Mapping
    {
        public Type SourceType { get; set; }
        public Type DestinationType { get; set; }
        public Func<object, object> MapFunc { get; set; } 
    }
}
