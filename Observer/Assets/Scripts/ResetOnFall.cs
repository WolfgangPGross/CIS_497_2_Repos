using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnFall : MonoBehaviour
{
    public Transform spawn;
    private Rigidbody rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -10)
        {
            //gameObject.transform.GetComponent<Rigidbody>().velocity.Set(0,0,0);
            rigidbody.velocity = Vector3.zero;

            gameObject.transform.position = spawn.position;
        }
    }
}
