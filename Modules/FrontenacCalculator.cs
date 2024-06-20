using Foe_Utils.Component;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foe_Utils.Modules
{
    public class FrontenacCalculator
    {
        public int levelToSee = 10;
        public Dictionary<int, double> firstTenLevels = new Dictionary<int, double> { 
            { 1, 0.5},
            { 2, 0.6},
            { 3, 0.7},
            { 4, 0.8},
            { 5, 0.9},
            { 6, 1},
            { 7, 1.05},
            { 8, 1.15},
            { 9, 1.25},
            { 10, 1.5},
        };
        public FrontenacCalculator() 
        {
            Console.Clear();
            Console.WriteLine(@"
    ______                 __                           ______      __           __      __            
   / ____/________  ____  / /____  ____  ____ ______   / ____/___ _/ /______  __/ /___ _/ /_____  _____
  / /_  / ___/ __ \/ __ \/ __/ _ \/ __ \/ __ `/ ___/  / /   / __ `/ / ___/ / / / / __ `/ __/ __ \/ ___/
 / __/ / /  / /_/ / / / / /_/  __/ / / / /_/ / /__   / /___/ /_/ / / /__/ /_/ / / /_/ / /_/ /_/ / /    
/_/   /_/   \____/_/ /_/\__/\___/_/ /_/\__,_/\___/   \____/\__,_/_/\___/\__,_/_/\__,_/\__/\____/_/     
                                                                                                       ");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"This calculator allows you to calculate how many goods you earn depending on the desired level, it also allows you to see the next {levelToSee} levels");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
        }
        public void calculate()
        {
            Console.Write("Enter the level: ");
            int level = 0;
            bool isValidNumber = int.TryParse(Console.ReadLine(), out level);
            if (isValidNumber)
            {
                int maxLevel = level + levelToSee;
                var table = new Table();

                table.AddColumn(new TableColumn("[deepskyblue1]Level[/]").Centered());
                table.AddColumn(new TableColumn("[deepskyblue1]Percentage[/]").Centered());
                table.AddColumn(new TableColumn("[deepskyblue1]Goods[/]").Centered());

                while (level <= maxLevel)
                {
                    double percentage = 0;
                    double goods = 0;
                    if (level < 10)
                    {
                        percentage = firstTenLevels[level] * 100;
                        goods = Math.Round(5 * firstTenLevels[level]) + 5;
                        table.AddRow(level.ToString(), percentage.ToString("N0") + "%", goods.ToString());
                    }
                    else
                    {
                        percentage = (level * 0.05) + 1;
                        goods = Math.Round(5 * percentage, MidpointRounding.AwayFromZero) + 5;
                        table.AddRow(level.ToString(), (percentage * 100).ToString("N0") + "%", goods.ToString());
                    }

                    level++;
                }


                Console.WriteLine();
                AnsiConsole.Write(table);
                Console.WriteLine();
                new Retry("Do you want to insert another level?", () => new FrontenacCalculator().calculate());
            }
            else
            {
                AnsiConsole.MarkupLine("[red underline]It is not a valid number[/]");
                Console.WriteLine("Press a button to retry");
                Console.ReadKey();
                new FrontenacCalculator().calculate();
            }

        }
 
    }
}
