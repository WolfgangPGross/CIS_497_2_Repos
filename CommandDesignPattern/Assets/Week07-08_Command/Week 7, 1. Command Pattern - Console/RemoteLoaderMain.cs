using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPatternConsole
{

    public class RemoteLoaderMain: MonoBehaviour
    {
        private void Start()
        {
        //create an instance of our remote control invoker
        RemoteControlInvokerWithUndo remoteControlInvoker = new RemoteControlInvokerWithUndo();

            //create instances for the devices or receivers
            //we will control with our remote control invoker
            DisplayText welcomeText = 
                new DisplayText("Welcome to the game!");
            DisplayText controlsText =
                new DisplayText("Here are the controls...");

            Teleport teleportPlayer =
                new Teleport("Player");
            Teleport teleportFrog =
                new Teleport("Frog");

            //Then we create instances of our commands and 
            //pass our devices or receivers to our commands as we create them
            DisplayTextShowCommand welcomeTextShow = new DisplayTextShowCommand(welcomeText);
            DisplayTextHideCommand welcomeTextHide = new DisplayTextHideCommand(welcomeText);

            DisplayTextShowCommand controlsTextShow = new DisplayTextShowCommand(controlsText);
            DisplayTextHideCommand controlsTextHide = new DisplayTextHideCommand(controlsText);

            TeleportToForestCommand teleportPlayerToForest = new TeleportToForestCommand(teleportPlayer);
            TeleportToLibraryCommand teleportPlayerToLibrary = new TeleportToLibraryCommand(teleportPlayer);
            TeleportToParkCommand teleportPlayerToPark = new TeleportToParkCommand(teleportPlayer);

            TeleportToForestCommand teleportFrogToForest = new TeleportToForestCommand(teleportFrog);
            TeleportToLibraryCommand teleportFrogToLibrary = new TeleportToLibraryCommand(teleportFrog);
            TeleportToParkCommand teleportFrogToPark = new TeleportToParkCommand(teleportFrog);


            //Add commands to our Remote Control Invoker 
            remoteControlInvoker.AddCommand("Show Welcome Text", welcomeTextShow);
            remoteControlInvoker.AddCommand("Hide Welcome Text", welcomeTextHide);
            remoteControlInvoker.AddCommand("Show Controls Text", controlsTextShow);
            remoteControlInvoker.AddCommand("Hide Controls Text", controlsTextHide);
            remoteControlInvoker.AddCommand("Teleport Player to Forest", teleportPlayerToForest);
            remoteControlInvoker.AddCommand("Teleport Player to Library", teleportPlayerToLibrary);
            remoteControlInvoker.AddCommand("Teleport Player to Park", teleportPlayerToPark);
            remoteControlInvoker.AddCommand("Teleport Frog to Forest", teleportFrogToForest);
            remoteControlInvoker.AddCommand("Teleport Frog to Library", teleportFrogToLibrary);
            remoteControlInvoker.AddCommand("Teleport Frog to Park", teleportFrogToPark);

            //Display commands on Remote Control Invoker
            remoteControlInvoker.DisplayCommands();

            //Invoke or Press Buttons on Remote Control Invoker, 
            //passing in the name of the command
            remoteControlInvoker.InvokeOrPressRemoteButton("Show Welcome Text");
            remoteControlInvoker.InvokeOrPressRemoteButton("Hide Welcome Text");
            remoteControlInvoker.InvokeUndoOrPressUndoButton();
            remoteControlInvoker.InvokeUndoOrPressUndoButton();
            remoteControlInvoker.InvokeUndoOrPressUndoButton();

            remoteControlInvoker.InvokeOrPressRemoteButton("Teleport Player to Forest");
            remoteControlInvoker.InvokeOrPressRemoteButton("Teleport Player to Library");
            remoteControlInvoker.InvokeOrPressRemoteButton("Teleport Player to Park");
            remoteControlInvoker.InvokeUndoOrPressUndoButton();
            remoteControlInvoker.InvokeUndoOrPressUndoButton();
            remoteControlInvoker.InvokeUndoOrPressUndoButton();
            remoteControlInvoker.InvokeUndoOrPressUndoButton();
            remoteControlInvoker.InvokeUndoOrPressUndoButton();

            //Let's set up a MacroCommand
            List<Command> startGame = new List<Command>();
            startGame.Add(teleportPlayerToForest);
            startGame.Add(welcomeTextShow);
            MacroCommand startGameMacro = new MacroCommand(startGame);
            remoteControlInvoker.AddCommand("Start Game Macro", startGameMacro);

            //Let's try out our Start Game Macro Command
            remoteControlInvoker.InvokeOrPressRemoteButton("Teleport Player to Library");
            
            remoteControlInvoker.InvokeOrPressRemoteButton("Start Game Macro");
            remoteControlInvoker.InvokeUndoOrPressUndoButton();
        }


    }
}