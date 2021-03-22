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

    public float speed;
    public float rotationSpeed;
    public float forceSpeed; 
    public Rigidbody rigidbody;

    //we replace the constructor with Awake() or Start()
    public void Start()
    {
        speed = 20f;
        rotationSpeed = 55f;
        forceSpeed = 12f;
        //rigidbody = GetComponent<Rigidbody>();
    }

    public Vector3 GetCurrentPosition()
    {
        return gameObject.transform.position;
    }

    public Quaternion GetCurrentRotation()
    {
        return gameObject.transform.rotation;
    }

    public Vector3 GetCurrentVelocity()
    {
        return gameObject.GetComponent<Rigidbody>().velocity;
    }

    public void MoveForward()
    {
        //transform.Translate(Vector3.right * Time.deltaTime * speed);
        rigidbody.AddRelativeForce(Vector3.right  * forceSpeed, ForceMode.Acceleration);
        //rigidbody.AddForce()
    }
    public void MoveBackward()
    {
        rigidbody.AddRelativeForce(Vector3.left * forceSpeed, ForceMode.Acceleration);

    }

    public void RotateRight()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
    public void RotateLeft()
    {
        transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed);
    }

}