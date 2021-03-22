using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPatternWithGameObjects
{
    public class MoveObject : MonoBehaviour
    {
        //We can use gameObject to refer to the object this script is attached to, so this reference is not needed
        //private GameObject objectToMove;

        public float speed;

        //we replace the constructor with Awake() or Start()
        public void Start()
        {
            speed = 10f;
        }

        public Vector3 GetCurrentPosition()
        {
            return gameObject.transform.position;
        }

        public void MoveForward()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        public void MoveLeft()
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        public void MoveRight()
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        public void MoveBack()
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }



    }
}