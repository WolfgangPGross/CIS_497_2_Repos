using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeft : Command
{
    MoveObject moveObject;

    Stack<Vector3> positionHistory;
    Stack<Quaternion> rotationHistory;
    Stack<Vector3> velocityHistory;

    public RotateLeft(MoveObject moveObject)
    {
        this.moveObject = moveObject;
        positionHistory = new Stack<Vector3>();
        rotationHistory = new Stack<Quaternion>();
        velocityHistory = new Stack<Vector3>();
    }

    public void Execute()
    {
        positionHistory.Push(moveObject.GetCurrentPosition());
        rotationHistory.Push(moveObject.GetCurrentRotation());
        velocityHistory.Push(moveObject.GetCurrentVelocity());

        moveObject.RotateLeft();

    }

    public void Undo()
    {
        //consider Undoing the move left towards a move to the right...
        //moveObject.MoveRight();

        //Assign the Vector3 position in our positionHistory stack to our gameObject
        if (positionHistory.Count != 0)
        {
            moveObject.gameObject.transform.rotation = rotationHistory.Pop();
            moveObject.gameObject.transform.position = positionHistory.Pop();
            moveObject.gameObject.GetComponent<Rigidbody>().velocity = velocityHistory.Pop();
        }
    }
}