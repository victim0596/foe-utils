using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foe_Utils.Component
{
    public class LogoStartup
    {
        public void LoadLogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(@"
 _______  _______  _______            __________________ _       ___________________________ _______  _______ 
(  ____ \(  ___  )(  ____ \  |\     /|\__   __/\__   __/( \      \__   __/\__   __/\__   __/(  ____ \(  ____ \
| (    \/| (   ) || (    \/  | )   ( |   ) (      ) (   | (         ) (      ) (      ) (   | (    \/| (    \/
| (__    | |   | || (__      | |   | |   | |      | |   | |         | |      | |      | |   | (__    | (_____ 
|  __)   | |   | ||  __)     | |   | |   | |      | |   | |         | |      | |      | |   |  __)   (_____  )
| (      | |   | || (        | |   | |   | |      | |   | |         | |      | |      | |   | (            ) |
| )      | (___) || (____/\  | (___) |   | |   ___) (___| (____/\___) (___   | |   ___) (___| (____/\/\____) |
|/       (_______)(_______/  (_______)   )_(   \_______/(_______/\_______/   )_(   \_______/(_______/\_______)
                                                                                                                          
");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
