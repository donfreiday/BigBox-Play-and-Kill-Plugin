// Big Box Play and Kill Plugin for Launchbox
// Adds a context menu option to each game allowing the user to kill Big Box after starting the game.
// Author: Don Freiday
// 05/11/2017

using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace BigBox_Play_and_Kill
{
    public class BigBox_Play_and_Kill : IGameMenuItemPlugin
    {
        public bool SupportsMultipleGames
        {
            get
            {
                return false;
            }
        }

        public string Caption
        {
            get
            {
                return "Play and kill BigBox";
            }
        }

        public System.Drawing.Image IconImage
        {
            get
            {
                return null;
            }
        }

        public bool ShowInLaunchBox
        {
            get
            {
                return false;
            }
        }

        public bool ShowInBigBox
        {
            get
            {
                return true;
            }
        }

        public bool GetIsValidForGame(IGame selectedGame)
        {
            return true;
        }

        public bool GetIsValidForGames(IGame[] selectedGames)
        {
            return true;
        }

        public void OnSelected(IGame selectedGame)
        {
            selectedGame.Play();
            foreach (var process in System.Diagnostics.Process.GetProcessesByName("BigBox"))
            {
                process.Kill();
            }
        }

        public void OnSelected(IGame[] selectedGames)
        {
            return;
        }
    }
}
