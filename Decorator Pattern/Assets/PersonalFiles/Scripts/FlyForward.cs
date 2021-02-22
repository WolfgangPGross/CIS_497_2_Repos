using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyForward : MonoBehaviour
{
    public float projectileSpeed = 10f;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
        //StartCoroutine(WaitTodie());
    }

    /*IEnumerable WaitTodie()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Do Nothing");
    }*/
}
