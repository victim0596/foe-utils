using Foe_Utils.Component;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foe_Utils
{
    public class Startup
    {
        public void Start()
        {
            Console.Clear();
            LogoStartup logo = new LogoStartup();
            logo.LoadLogo();
            Menu menu = new Menu();
            menu.LoadMenu();
            Console.ReadKey();
        }
    }
}
