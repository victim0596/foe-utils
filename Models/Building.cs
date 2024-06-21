using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foe_Utils.Models
{
    public class Building
    {
        public string name { get; set; }
        public int xSize { get; set; }
        public int ySize { get; set; }
        public string roadRequired { get; set; }
        public int forgePoints { get; set; }
        public int attAtt { get; set; }
        public int defAtt { get; set; }
        public int attDef { get; set; }
        public int defDef { get; set; }
        public int goods { get; set; }
        public int troops { get; set; }
    }
}
