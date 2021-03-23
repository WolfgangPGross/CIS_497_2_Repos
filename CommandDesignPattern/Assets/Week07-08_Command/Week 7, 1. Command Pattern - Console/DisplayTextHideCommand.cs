using UnityEngine;
using System.Collections;

namespace CommandPatternConsole
{

    public class DisplayTextHideCommand : Command
    {
        DisplayText displayText;

        public DisplayTextHideCommand(DisplayText displayText)
        {
            this.displayText = displayText;
        }

        public void Execute()
        {
            this.displayText.Hide();
        }

        public void Undo()
        {
            this.displayText.Show();
        }
    }
}