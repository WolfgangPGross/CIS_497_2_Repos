using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeft : Command
{
    RotateObject rotateObject;

    Stack<Quaternion> rotationHistory;

    public RotateLeft(RotateObject rotateObject)
    {
        this.rotateObject = rotateObject;
        rotationHistory = new Stack<Quaternion>();
    }    

    public void Execute()
    {
        //positionHistory.Push(moveObject.GetCurrentPosition());
        rotationHistory.Push(rotateObject.GetCurrentRotation());
        //velocityHistory.Push(moveObject.GetCurrentVelocity());

        rotateObject.RotateLeft();

    }

    public void Undo()
    {
        //consider Undoing the move left towards a move to the right...
        //moveObject.MoveRight();

        //Assign the Vector3 position in our positionHistory stack to our gameObject
        if (rotationHistory.Count != 0)
        {
            rotateObject.gameObject.transform.rotation = rotationHistory.Pop();
            //moveObject.gameObject.transform.position = positionHistory.Pop();
            //moveObject.gameObject.GetComponent<Rigidbody>().velocity = velocityHistory.Pop();
        }
    }
}