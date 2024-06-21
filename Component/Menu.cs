using Foe_Utils.Constant;
using Foe_Utils.Modules;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Foe_Utils.Component
{
    public class Menu
    {
        public void LoadMenu()
        {
            var voices = Constant.Constant.voicesMenu.Select(x => x.VoiceName);
            var prompt = new SelectionPrompt<string>()
                .Title("This application contains useful modules, choose the one you need")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down)[/]")
                .AddChoices(voices);
            var voiceMenuString = AnsiConsole.Prompt(prompt);
            var menuVoiceId = Constant.Constant.voicesMenu.Where(x=> x.VoiceName == voiceMenuString).Select(x=> x.Id).FirstOrDefault();
            LoadVoiceMenu(menuVoiceId);
        }

        public void LoadVoiceMenu(int idMenu)
        {
            Dictionary<int, Action> dictionaryMenu = new Dictionary<int, Action>();
            dictionaryMenu.Add(0, () => new CalculateGeTitan().calculate());
            dictionaryMenu.Add(1, () => new FrontenacCalculator().calculate());
            dictionaryMenu.Add(2, () => new CalculateBuildingEfficiency().calculate());
            dictionaryMenu.Add(99, () => Environment.Exit(0));
            dictionaryMenu[idMenu]();
        }
    }
}
