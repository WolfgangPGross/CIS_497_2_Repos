using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPatternConsole
{

    public class RemoteControlInvokerWithUndo
    {
        //To review C# collections like Dictionaries and Stacks
        //see http://www.newthinktank.com/2017/02/c-tutorial-11/

        Dictionary<string, Command> commands;
        
        Stack<Command> commandHistory;


        public RemoteControlInvokerWithUndo()
        {
            commands = new Dictionary<string, Command>();
            commandHistory = new Stack<Command>();

        }

        public void AddCommand(string slotName, Command command)
        {
            commands.Add(slotName,command);
        }

        public void DisplayCommands()
        {
            Debug.Log("----- List of Commands in Remote Control -----\n");
            foreach (KeyValuePair<string, Command> command in commands)
            {
                Debug.Log(command.Key + ": " + command.Value.GetType().Name + "\n");
            }
        }

        public void InvokeOrPressRemoteButton(string slotName)
        {
            //Try to get the command with the slotName
            commands.TryGetValue(slotName, out Command command);
            //Call execute on command if command is not null
            if (command != null) { command.Execute(); }

            //A shorter way to write the line above is:
            //command?.Execute();
            
            //set undoCommand to command - undoCommand is not currently used
            //undoCommand = command;

            //Add command to command history stack
            commandHistory.Push(command);
        }

        public void InvokeUndoOrPressUndoButton()
        {
            if(commandHistory.Count != 0)
            {
                Debug.Log("Undoing...");
                Command command = commandHistory.Pop();
                command.Undo();
            }
            else
            {
                Debug.Log("You tried to undo, but there are no more commands to undo.");
            }
        }

    }
}