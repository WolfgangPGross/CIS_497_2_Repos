using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPatternConsole
{
    public class MacroCommand : Command
    {
        List<Command> commands;

        public MacroCommand(List<Command> commands)
        {
            this.commands = commands;
        }

        public void Execute()
        {
            foreach (Command command in commands)
            {
                command.Execute();
            }
        }
        public void Undo()
        {
            //commands have to be done backwards to ensure proper undo functionality
            for (int i = commands.Count - 1; i >= 0; i--)
            {
                commands[i].Undo();
            }
        }

    }
}