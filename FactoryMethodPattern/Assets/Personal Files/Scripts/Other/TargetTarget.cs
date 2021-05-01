using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTarget : MonoBehaviour
{
    Rigidbody rigidbody;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.AddComponent<Rigidbody>();
       rigidbody = gameObject.AddComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitToDie());
        //rigidbody.AddForce(target.transform.position - gameObject.transform.position * Time.deltaTime);
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this);
    }
}
