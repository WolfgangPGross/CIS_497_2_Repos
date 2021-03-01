using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float xRange = 4;
    private float ySpawnPos = -6;
    private bool cooledDown = true;

    private string tempSpawn;

    //Need to attach the simple factory GameObject to this reference in the inspector
    public SpawnManagerFactory factory;

    private GameObject spawn;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
           
            if (cooledDown == true)
            {
                Debug.Log("Got to spawning");
                StartCoroutine(SpawnTarget());

                cooledDown = false;
            }
        }
        if (Input.GetKey(KeyCode.B))
        {
            SpawnObject("Low");
        }
        if (Input.GetKey(KeyCode.N))
        { 
            SpawnObject("Mid");
        }
        if (Input.GetKey(KeyCode.M))
        {
            SpawnObject("High");
        }
    }

    public void SpawnObject(string type)
    {
        Debug.Log("Type passed in: " + type);
        spawn = factory.CreateSpawn(type);
        Debug.Log(spawn);

        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);

        Instantiate(spawn, spawnPos, spawn.transform.rotation);
        cooledDown = true;
    }

    IEnumerator SpawnTarget()
    {
        Debug.Log("Got to SpawnTarget begin");
        //Wait 1.5 second
        yield return new WaitForSeconds(0.25f);

        //Pick a random index between 0 and number of prefabs
        int index = Random.Range(0, 3);

        if(index == 0)
        {
            tempSpawn = "Low";
        }
        else if (index == 1)
        {
            tempSpawn = "Mid";
        }
        if (index == 2)
        {
            tempSpawn = "High";
        }
        Debug.Log("Type: " + tempSpawn);

        SpawnObject(tempSpawn);
        Debug.Log("Got to SpawnTarget End");

    }
}
