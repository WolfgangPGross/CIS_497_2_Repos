using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPatternConsole
{
    public class Teleport
    {
        private string objectToTeleport;

        private string currentPosition;

        public Teleport(string objectToTeleport)
        {
            this.objectToTeleport = objectToTeleport;
            this.currentPosition = null;
        }

        public string GetCurrentPosition()
        {
            return this.currentPosition;
        }

        public void TeleportToLibrary()
        {
            Debug.Log("Teleporting the " + this.objectToTeleport + " to the Library");
            currentPosition = "Library";
        }

        public void TeleportToPark()
        {
            Debug.Log("Teleporting the " + this.objectToTeleport + " to the Park");
            currentPosition = "Park";
        }

        public void TeleportToForest()
        {
            Debug.Log("Teleporting the " + this.objectToTeleport + " to the Forest");
            currentPosition = "Forest";
        }


    }
}