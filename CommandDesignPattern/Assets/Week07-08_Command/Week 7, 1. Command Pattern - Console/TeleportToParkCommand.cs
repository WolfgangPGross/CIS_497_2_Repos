using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPatternConsole
{
    public class TeleportToParkCommand : Command
    {
        Teleport teleport;

        Stack<string> teleportHistory;

        public TeleportToParkCommand(Teleport teleport)
        {
            this.teleport = teleport;
            teleportHistory = new Stack<string>();
        }

        public void Execute()
        {
            teleportHistory.Push(teleport.GetCurrentPosition());

            teleport.TeleportToPark();

        }

        public void Undo()
        {
            switch (teleportHistory.Pop())
            {
                case "Library":
                    teleport.TeleportToLibrary();
                    break;
                case "Park":
                    teleport.TeleportToPark();
                    break;
                case "Forest":
                    teleport.TeleportToForest();
                    break;
                default:
                    Debug.Log("No more teleport locations to undo.");
                    break;
            }
        }


    }

}