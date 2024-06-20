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
            new VoiceMenu { Id = 99, VoiceName = "Exit"}
        };
    }
}
