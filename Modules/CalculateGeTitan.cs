using Foe_Utils.Component;
using Foe_Utils.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foe_Utils.Modules
{
    public class CalculateGeTitan
    {
        public CalculateGeTitan()
        {
            Console.Clear();
            Console.WriteLine(@"
   ______      __           __      __          ____________   _______ __            
  / ____/___ _/ /______  __/ /___ _/ /____     / ____/ ____/  /_  __(_) /_____ _____ 
 / /   / __ `/ / ___/ / / / / __ `/ __/ _ \   / / __/ __/      / / / / __/ __ `/ __ \
/ /___/ /_/ / / /__/ /_/ / / /_/ / /_/  __/  / /_/ / /___     / / / / /_/ /_/ / / / /
\____/\__,_/_/\___/\__,_/_/\__,_/\__/\___/   \____/_____/    /_/ /_/\__/\__,_/_/ /_/ 
                                                                                     ");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"This calculator allows you to calculate the levels of Titan's three GEs based on the same amount of goods per level");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
        }

        public void calculate()
        {
            Console.Write("Enter HYDRA level: ");
            int level = 0;
            bool isValidNumber = int.TryParse(Console.ReadLine(), out level);
            if (isValidNumber)
            {
                GreatBuilding hydra = new GreatBuilding { Level = level, Goods = level < 10 ? 0 : 100 * (level - 10) };
                GreatBuilding centaurus = CalculateCentaurus(hydra);
                GreatBuilding pegasus = CalculatePegasus(hydra);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                AnsiConsole.Markup($"\n[red]Hydra's[/] level is [greenyellow]{hydra.Level}[/] and will require [lightskyblue1]{hydra.Goods}[/] goods\n\n");
                AnsiConsole.Markup($"[orange3]Centaurus's[/] level is [greenyellow]{centaurus.Level}[/] and will require [lightskyblue1]{centaurus.Goods}[/] goods\n\n");
                AnsiConsole.Markup($"[dodgerblue1]Pegasus's[/] level is [greenyellow]{pegasus.Level}[/] and will require [lightskyblue1]{pegasus.Goods}[/] goods\n\n");

                new Retry("Do you want to insert another level?", () => new CalculateGeTitan().calculate());
            }
            else
            {
                AnsiConsole.MarkupLine("[red underline]It is not a valid number[/]");
                Console.WriteLine("Press a button to retry");
                Console.ReadKey();
                new CalculateGeTitan().calculate();
            }
        }

        private GreatBuilding CalculateCentaurus(GreatBuilding hydra)
        {
            int centaurusGoods = hydra.Level < 10 ? 0 : 80 * (hydra.Level - 10);
            if (centaurusGoods > hydra.Goods)
            {
                return new GreatBuilding { Goods = 80 * (hydra.Level - 11), Level = hydra.Level - 1 };
            }
            else
            {
                return CalculateCentaurus(new GreatBuilding { Goods = hydra.Goods, Level = hydra.Level + 1 });
            }
        }
        private GreatBuilding CalculatePegasus(GreatBuilding hydra)
        {
            int pegasusGoods = hydra.Level < 10 ? 0 : 60 * (hydra.Level - 10);
            if (pegasusGoods > hydra.Goods)
            {
                return new GreatBuilding { Goods = 60 * (hydra.Level - 11), Level = hydra.Level - 1 };
            }
            else
            {
                return CalculatePegasus(new GreatBuilding { Goods = hydra.Goods, Level = hydra.Level + 1 });
            }
        }
    }
}
