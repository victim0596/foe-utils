using Foe_Utils.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foe_Utils.Modules
{
    public class Exit
    {
        public Exit() 
        {
            Console.Clear();
            new LogoStartup().LoadLogo();
            Console.WriteLine("\nBYE!!!\n[Press any button to close]");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
