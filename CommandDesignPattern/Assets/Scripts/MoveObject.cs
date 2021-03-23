using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Wolfgang Gross
 * CIS 497 2
 * 
 * Command Design Pattern
 * 
 * Receiver
 * */

public class MoveObject : MonoBehaviour
{
    //We can use gameObject to refer to the object this script is attached to, so this reference is not needed
    //private GameObject objectToMove;

    public float forceSpeed; 
    public Rigidbody rigidbody;

    //we replace the constructor with Awake() or Start()
    public void Start()
    {
        forceSpeed = 30f;
    }

    public Vector3 GetCurrentPosition()
    {
        return gameObject.transform.position;
    }

    public Vector3 GetCurrentVelocity()
    {
        return gameObject.GetComponent<Rigidbody>().velocity;
    }

    public void MoveForward()
    {
        rigidbody.AddRelativeForce(Vector3.right * forceSpeed, ForceMode.Acceleration);
    }
    public void MoveBackward()
    {
        rigidbody.AddRelativeForce(Vector3.left * forceSpeed, ForceMode.Acceleration);

    }
}