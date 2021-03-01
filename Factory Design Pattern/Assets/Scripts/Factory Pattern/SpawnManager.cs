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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(cooledDown == true)
            {
                cooledDown = false;
                SpawnTarget();
            }
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
        //Wait 1.5 second
        yield return new WaitForSeconds(1.5f);

        //Pick a random index between 0 and number of prefabs
        int index = Random.Range(0, 3);

        if(index == 0)
        {
            string tempSpawn = "Low";
        }
        else if (index == 1)
        {
            string tempSpawn = "Mid";
        }
        if (index == 2)
        {
            string tempSpawn = "High";
        }

        SpawnObject(tempSpawn);

        tempSpawn = "";
    }
}

}