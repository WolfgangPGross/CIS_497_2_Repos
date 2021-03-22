using UnityEngine;
using System.Collections;

namespace CommandPatternConsole
{
    public class DisplayText
    {
        public bool isActive;
        public string textToDisplay;

        public DisplayText(string textToDisplay)
        {
            this.textToDisplay = textToDisplay;
        }

        public void Show()
        {
            isActive = true;
            Debug.Log("This text is now showing on screen:\n" + textToDisplay);
        }

        public void Hide()
        {
            isActive = false;
            Debug.Log("This text is hidden now, not showing on screen:\n" + textToDisplay);
        }



    }
}