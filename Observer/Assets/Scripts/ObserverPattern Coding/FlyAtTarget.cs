using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAtTarget : MonoBehaviour
{
    private GameObject target;
    public float flySpeed = 3f;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, flySpeed * Time.deltaTime);
        transform.LookAt(target.transform);

        rigidbody.AddForce(target.transform.position - transform.position * flySpeed, ForceMode.Acceleration);
    }

    public void changeTarget(GameObject newTarget)
    {
        target = newTarget;
        //Debug.Log("Target Changed to [" + newTarget.name + "]");
    }
 
}
