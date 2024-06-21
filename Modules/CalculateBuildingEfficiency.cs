using Foe_Utils.Component;
using Foe_Utils.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Foe_Utils.Modules
{
    public class CalculateBuildingEfficiency
    {
        public Dictionary<string, string> questions = new Dictionary<string, string>
        {
            { "What is the name of building? ", "name"},
            { "What is the [blue]x[/] size? ", "xSize" },
            { "What is the [red]y[/] size? ", "ySize" },
            { "The building require a connection (road or something else)(true or false)? ", "roadRequired" },
            { "How many [gold3_1]forge point[/] produce? ", "forgePoints"},
            { "How much [orange3]attack[/] per [orange3]attack[/]? ", "attAtt"},
            { "How much [orange3]defence[/] per [orange3]attack[/]? ", "defAtt"},
            { "How much [deepskyblue1]attack[/] per [deepskyblue1]defence[/]? ", "attDef"},
            { "How much [deepskyblue1]defence[/] per [deepskyblue1]defence[/]? ", "defDef"},
            { "How many [lightskyblue1]goods[/] produce? ", "goods"},
            { "How many [grey69]troops[/] produce? ", "troops"}
        };
        public CalculateBuildingEfficiency()
        {
            Console.Clear();
            Console.WriteLine(@"
    ____        _ __    ___                _______________      _                      
   / __ )__  __(_) /___/ (_)___  ____ _   / ____/ __/ __(_)____(_)__  ____  _______  __
  / __  / / / / / / __  / / __ \/ __ `/  / __/ / /_/ /_/ / ___/ / _ \/ __ \/ ___/ / / /
 / /_/ / /_/ / / / /_/ / / / / / /_/ /  / /___/ __/ __/ / /__/ /  __/ / / / /__/ /_/ / 
/_____/\__,_/_/_/\__,_/_/_/ /_/\__, /  /_____/_/ /_/ /_/\___/_/\___/_/ /_/\___/\__, /  
                              /____/                                          /____/   ");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"This calculator allows you to calculate the building efficienty per tile.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
        }

        public void calculate()
        {
            Building building = dataReading();
            var table = new Table();
            table.AddColumn(new TableColumn("Building name").Centered());
            table.AddColumn(new TableColumn("[blue]x Size[/]").Centered());
            table.AddColumn(new TableColumn("[red]y Size[/]").Centered());
            table.AddColumn(new TableColumn("Road Required").Centered());
            table.AddColumn(new TableColumn("[gold3_1]Forge points[/]").Centered());
            table.AddColumn(new TableColumn("[orange3]Attack[/] per [orange3]attack[/]").Centered());
            table.AddColumn(new TableColumn("[orange3]Defence[/] per [orange3]attack[/]").Centered());
            table.AddColumn(new TableColumn("[deepskyblue1]Attack[/] per [deepskyblue1]defence[/]").Centered());
            table.AddColumn(new TableColumn("[deepskyblue1]Defence[/] per [deepskyblue1]defence[/]").Centered());
            table.AddColumn(new TableColumn("[lightskyblue1]Goods[/]").Centered());
            table.AddColumn(new TableColumn("[grey69]Troops[/]").Centered());
            table.AddColumn(new TableColumn("Efficiency").Centered());

            double efficiencyTotal = calculateEfficiency(building);
            string efficiencyString = efficiencyTotal < 100 ? $"[red]{efficiencyTotal.ToString("N0")}%[/]" : $"[green]{efficiencyTotal.ToString("N0")}%[/]";
            table.AddRow(building.name, 
                building.xSize.ToString(), 
                building.ySize.ToString(), 
                building.roadRequired, 
                building.forgePoints.ToString(),
                building.attAtt.ToString(),
                building.defAtt.ToString(),
                building.attDef.ToString(),
                building.defDef.ToString(),
                building.goods.ToString(),
                building.troops.ToString(),
                efficiencyString
                );

            Console.WriteLine();
            AnsiConsole.Write(table);
            Console.WriteLine();
            new Retry("Do you want to calculate another building?", () => new CalculateBuildingEfficiency().calculate());

        }

        private Building dataReading()
        {
            Building building = new Building();
            Type type = building.GetType();
            foreach (var item in questions)
            {
                AnsiConsole.Markup(item.Key);
                PropertyInfo prop = type.GetProperty(item.Value);
                if (prop.PropertyType == typeof(int))
                {
                    int value = 0;
                    bool isValid = int.TryParse(Console.ReadLine(), out value);
                    while (!isValid)
                    {
                        AnsiConsole.MarkupLine("[red underline]It is not a valid number[/]");
                        Console.WriteLine("Try again on the next line...");
                        isValid = int.TryParse(Console.ReadLine(), out value);
                    }
                    prop.SetValue(building, value);
                }
                else
                {
                    string value = Console.ReadLine();
                    if (prop.Name == "roadRequired")
                    {
                        bool isValidRoad = (value == "true" || value == "false") ? true : false;
                        while (!isValidRoad)
                        {
                            AnsiConsole.MarkupLine("[red underline]It is not a valid road value[/]");
                            Console.WriteLine("Try again on the next line...");
                            value = Console.ReadLine();
                            isValidRoad = (value == "true" || value == "false") ? true : false;
                        }
                    }                   
                    prop.SetValue(building, value);
                }
            }
            return building;
        }
        private double calculateEfficiency(Building building)
        {
            double efficiency = 0;
            double total = 0;
            Type type = building.GetType();
            foreach (var item in Constant.Constant.prodTileValue)
            {
                PropertyInfo prop = type.GetProperty(item.Key);
                int propValue = (int)prop.GetValue(building);
                total = total + (propValue / item.Value); 
            }
            int minimum = building.xSize > building.ySize ? building.ySize : building.xSize;
            int road = building.roadRequired == "true" ? 1 : 0;
            int roadValue = (minimum * road) / 2;
            efficiency = total / ((building.xSize * building.ySize) + roadValue);
            return efficiency * 100;
        }

    }
}
