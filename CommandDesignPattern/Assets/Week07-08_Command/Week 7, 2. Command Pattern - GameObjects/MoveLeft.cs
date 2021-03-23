using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPatternWithGameObjects
{
    public class MoveLeft : Command
    {
        MoveObject moveObject;

        Stack<Vector3> positionHistory;

        public MoveLeft(MoveObject moveObject)
        {
            this.moveObject = moveObject;
            positionHistory = new Stack<Vector3>();
        }

        public void Execute()
        {
            positionHistory.Push(moveObject.GetCurrentPosition());

            moveObject.MoveLeft();

        }

        public void Undo()
        {
            //You could consider Undoing the move left with a move to the right...
            //moveObject.MoveRight();

            //Instead, we will assign the Vector3 position in our positionHistory stack to our gameObject
            if (positionHistory.Count != 0)
            {
                moveObject.gameObject.transform.position = positionHistory.Pop();
            }
            
        }


    }

}