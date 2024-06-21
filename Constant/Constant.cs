using Foe_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foe_Utils.Constant
{
    public static class Constant
    {
        public static List<VoiceMenu> voicesMenu = new List<VoiceMenu>
        {
            new VoiceMenu { Id = 0, VoiceName = "Calculate GE Titan"},
            new VoiceMenu { Id = 1, VoiceName = "Frontenac Good calculator"},
            new VoiceMenu { Id = 2, VoiceName = "Calculate building efficiency"},
            new VoiceMenu { Id = 99, VoiceName = "Exit"}
        };
        public static Dictionary<string, double> prodTileValue = new Dictionary<string, double>
        {
            { "forgePoints", 0.8},
            { "attAtt", 2},
            { "defAtt", 2},
            { "attDef", 2},
            { "defDef", 2},
            { "goods", 1.8},
            { "troops", 0.2}
        };
    }
}
