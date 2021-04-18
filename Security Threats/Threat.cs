using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_Threats
{
    public class Threat
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Impact { get; set; }
        public string Confidentiality { get; set; }
        public string Integrity { get; set; }
        public string Accessibility { get; set; }

        
    }
}
