using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    *Wolfgang Gross
    * CIS497 - ObjectPooler Pattern
    * 
    * Spawns from Recycled pools of Instantiated Objects to save on performance
    */

public class PrefabSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    private bool cooledDown = true;
    private bool mePlaying;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void FixedUpdate()
    {
        //Change to new prefab spawn
        //objectPooler.SpawnFromPool("Sphere", transform.position, Quaternion.identity);
        mePlaying = GameManager.Instance.playing;


        if (mePlaying && cooledDown == true)
        {
            cooledDown = false;
            StartCoroutine(DoSpawning());
        }
        
    }

    IEnumerator DoSpawning()
    {
        yield return new WaitForSeconds(0.85f);
        cooledDown = true;

        //Choose between either pool
        int temp = Random.Range(0, 3);
        if (temp < 2)
        {
            ObjectPooler.Instance.SpawnFromPool("Good", transform.position, Quaternion.identity);
            //ObjectPooler.Instance.
        }
        else
        {
            ObjectPooler.Instance.SpawnFromPool("Bad", transform.position, Quaternion.identity);
        }

    }
}
