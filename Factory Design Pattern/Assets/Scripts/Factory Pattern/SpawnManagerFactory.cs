using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this class to an empty GameObject
public class SpawnManagerFactory : MonoBehaviour
{
    public GameObject HighPointPrefab;
    public GameObject MidPointPrefab;
    public GameObject LowPointPrefab;

    private GameObject spawnToCreate;

    public GameObject CreateSpawn(string type)
    {
        spawnToCreate = null;

        if (type.Equals("Low"))
        {
            spawnToCreate = LowPointPrefab;

            //If there is not already a Zombie script attached to the prefab, attach one
            if (spawnToCreate.GetComponent<LowPointSpawn>() == null)
            {
                spawnToCreate.AddComponent<LowPointSpawn>();
            }
        }
        else if (type.Equals("Mid"))
        {
            spawnToCreate = MidPointPrefab;

            //If there is not already a Vampire script attached to the prefab, attach one
            if (spawnToCreate.GetComponent<MidPointSpawn>() == null)
            {
                spawnToCreate.AddComponent<MidPointSpawn>();
            }
        }
        else if (type.Equals("High"))
        {
            spawnToCreate = HighPointPrefab;

            //If there is not already a Werewolf script attached to the prefab, attach one
            if (spawnToCreate.GetComponent<HighPointSpawn>() == null)
            {
                spawnToCreate.AddComponent<HighPointSpawn>();
            }
        }
        Debug.Log("Factory sending: " + spawnToCreate);
        return spawnToCreate;
    }
}