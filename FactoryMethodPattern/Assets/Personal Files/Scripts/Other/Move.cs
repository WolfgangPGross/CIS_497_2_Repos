using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{ 
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Transform>().Translate(Vector3.forward * Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Transform>().Translate(Vector3.left * Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Transform>().Translate(Vector3.right * Time.deltaTime * 10f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.GetComponent<Transform>().Translate(Vector3.back * Time.deltaTime * 10f);
        }
    }
}
