using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Wolfgang Gross
 * CIS 497 2
 * 
 * Command Design Pattern
 * 
 * Invoker
 * */

public class PlayerInputInvoker : MonoBehaviour
{
    public MoveObject moveObject;
    private Command moveForward;
    private Command moveBackward;
    private Command rotateRight;
    private Command rotateLeft;

    //A stack of commands to keep track of the history of commands
    public Stack<Command> commandHistory;

    // Initialize commands and our stack of commands using Awake or Start
    void Awake()
    {
        moveForward = new MoveForward(moveObject);
        moveBackward = new MoveBackward(moveObject);
        rotateLeft = new RotateLeft(moveObject);
        rotateRight = new RotateRight(moveObject);

        commandHistory = new Stack<Command>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveForward.Execute();
            commandHistory.Push(moveForward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveBackward.Execute();
            commandHistory.Push(moveBackward);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotateLeft.Execute();
            commandHistory.Push(rotateLeft);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rotateRight.Execute();
            commandHistory.Push(rotateRight);
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