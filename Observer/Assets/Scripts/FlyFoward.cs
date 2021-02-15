using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyFoward : MonoBehaviour
{
    public float projectileSpeed;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(transform.forward * projectileSpeed , ForceMode.Impulse);
    }
}
