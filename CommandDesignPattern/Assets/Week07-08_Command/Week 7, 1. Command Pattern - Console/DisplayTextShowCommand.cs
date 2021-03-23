using UnityEngine;
using System.Collections;

namespace CommandPatternConsole
{

    public class DisplayTextShowCommand : Command
    {
        DisplayText displayText;

        public DisplayTextShowCommand(DisplayText displayText)
        {
            this.displayText = displayText;
        }

        public void Execute()
        {
            this.displayText.Show();
        }

        public void Undo()
        {
            this.displayText.Hide();
        }
    }
}