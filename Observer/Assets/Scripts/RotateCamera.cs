using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    public float leftInput;
    public float rightInput;

    public float upInput;
    public float downInput;


    //Reference to FocalPoint Transform
    //public Transform focal_Point;

    //variables for two focal objects
    //public Transform focal_Object_1;
    //public Transform focal_Object_2; //-If doesn't exist, only rotate around object_1

    private void Start()
    {
        //focal_Point = gameObject.transform;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            upInput = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            downInput = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightInput = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftInput = 1;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            upInput = 0;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            downInput = 0;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rightInput = 0;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            leftInput = 0;
        }

        //Reset Z rotation
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);

        //float horizontalInput = Input.GetKey(KeyCode.UpArrow);
        float horizontalInput = rightInput - leftInput;
        transform.Rotate(Vector3.down, horizontalInput * rotationSpeed * Time.deltaTime);

        //float verticalInput = Input.GetAxis("Vertical");
        float verticalInput = upInput - downInput;
        transform.Rotate(Vector3.right, verticalInput * rotationSpeed * Time.deltaTime);

        //Update position of Focalpoint to be in the middle of the two player objects
        //tempMiddle = new Vector3(focal_Object_1.position - focal_Object_2.position);    
        //gameObject.transform.position = (focal_Object_1.position - focal_Object_2.position) / 2;
    }
}
