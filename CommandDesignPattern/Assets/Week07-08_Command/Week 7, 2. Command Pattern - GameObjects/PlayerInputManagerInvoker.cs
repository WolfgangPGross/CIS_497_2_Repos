using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPatternWithGameObjects
{
    public class PlayerInputManagerInvoker : MonoBehaviour
    {
        public MoveObject moveObject;
        private Command moveLeft;
        private Command moveRight;

        //A stack of commands to keep track of the history of commands
        public Stack<Command> commandHistory;

        // Initialize commands and our stack of commands using Awake or Start
        void Awake()
        {
            moveLeft = new MoveLeft(moveObject);
            moveRight = new MoveRight(moveObject);
            commandHistory = new Stack<Command>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveLeft.Execute();
                commandHistory.Push(moveLeft);
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveRight.Execute();
                commandHistory.Push(moveRight);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                if (commandHistory.Count != 0)
                { 
                    //pop the last command off our stack
                    Command lastCommand = commandHistory.Pop();

                    //call Undo() on the last command
                    lastCommand.Undo();
                }
            }


        }



    }
}