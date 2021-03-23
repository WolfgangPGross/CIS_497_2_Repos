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

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed;
    public Rigidbody rigidbody;

    public void Start()
    {
        rotationSpeed = 120f;
    }

    public Quaternion GetCurrentRotation()
    {
        return gameObject.transform.rotation;
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