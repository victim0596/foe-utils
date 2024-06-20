using Foe_Utils.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foe_Utils.Component
{
    public class Retry
    {
        public Retry(string customSentence, Action componentToExecute)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{customSentence}[y/n]:");
            string value = Console.ReadLine();
            if (value == "y") componentToExecute();
            else
            {
                Console.WriteLine("\nYou will be returned to the menu ...\n[Press any button to continue]");
                Console.ReadKey();
                new Startup().Start();
            }
        }
    }
}
