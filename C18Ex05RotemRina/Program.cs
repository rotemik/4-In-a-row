using System;
using System.Collections.Generic;
using System.Text;

// $G$ SFN-999 (-5) the board buttons should be disabled

namespace C18_Ex05
{
    public class Program
    {
        public static void Main()
        {
            // $G$ CSS-999 (-3) local variable name should be camel Cased
            GameSettingsD i_GameSettingForm = new GameSettingsD();
            i_GameSettingForm.ShowDialog(); // open settings dialog
        }
    }
}
