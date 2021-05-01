using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Wolfgang Gross
 * CIS 497
 * Factory Method Pattern
 */

public class SentrySpawner : MonoBehaviour
{
    public float spawnDistance;
    private Transform playerOrCameraTransform;

    public SentryCreator sentryCreator;
    public SentryCreator sentryCreator2;

    public SentryStation sentryStation;
    public SentryRoam sentryRoam;

    public bool sentryCreatorIsStationed;

    public List<GameObject> Stations;
    public List<GameObject> Roams;

    // Start is called before the first frame update
    void Start()
    {
        spawnDistance = 20f;
        playerOrCameraTransform = Camera.main.transform;

        sentryCreator = new SentryStation();

        //Swap between two spawns
        //sentryCreator2 = new SentryRoam();

        //npcCreatorIsAlly = true;
    }

    public GameObject SpawnSentry(string type)
    {
        GameObject sentry = null;

        //Assign prefab to npc
        sentry = sentryCreator.CreateSentryPrefab(type);

        //Set the spawn position
        float xRand = Random.Range(-10, 10);
        float zRand = Random.Range(-10, 10);
        Vector3 spawnPos = playerOrCameraTransform.position +
                           playerOrCameraTransform.forward * spawnDistance +
                           new Vector3(xRand, 0, zRand);

        Quaternion quat = new Quaternion(0, 0, 0, 0);
        //Spawn the sentry and assign the instance to npcInstance
        GameObject sentryInstance = Instantiate(sentry, spawnPos, quat/*playerOrCameraTransform.rotation*/);

        //Add script to our npc instance
        sentryCreator.AddSentryScript(sentryInstance, type);


        //return the npc instance
        return sentryInstance;

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Swap Sentry key pressed");
            //Debug.Log(sentryCreator.GetType());
            //Debug.Log(sentryCreator.GetType().Equals("FactoryMethodPatternWithGameObjects.SentryCreator"));

            if (sentryCreatorIsStationed)
            {
                sentryCreator = new SentryRoam();
                sentryCreatorIsStationed = false;
            }
            else
            {
                sentryCreator = new SentryStation();
                sentryCreatorIsStationed = true;
            }

            //Debug.Log(sentryCreator.GetType());
            //Debug.Log(sentryCreator.GetType().Equals("FactoryMethodPatternWithGameObjects.EnemyCreator"));

        }

        //Spawn Tanks
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (sentryCreatorIsStationed)
            {
                Stations.Add(SpawnSentry("Tank"));
            }
            else
            {
                Roams.Add(SpawnSentry("Tank"));
            }

        }

        //Spawn Turrets
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (sentryCreatorIsStationed)
            {
                Stations.Add(SpawnSentry("Turret"));
            }
            else
            {
                Roams.Add(SpawnSentry("Turret"));
            }
        }

        //Force Attacks
        if (Input.GetKeyDown(KeyCode.Space))
        {

            foreach (GameObject station in Stations)
            {
                //using polymorphism with GetComponent, Attack is called on the supertype Sentry
                station.GetComponent<Sentry>().Attack();
            }

            foreach (GameObject roam in Roams)
            {
                roam.GetComponent<Sentry>().Attack();
            }

        }

        //We can use foreach to move our whole list of game objects as well...
        //this example uses Transform.Translate(), but we could add rigidbodies to prefabs and add forces
        /*if (Input.GetKey(KeyCode.W))
        {
            if(sentryCreatorIsStationed)
            {
                foreach (GameObject ally in Stations)
                {
                    //using polymorphism with GetComponent, the gameobjects are moved with WASD
                    ally.GetComponent<Transform>().Translate(Vector3.forward * Time.deltaTime * 10f);
                }
            }
            else
            {
                foreach (GameObject ally in Roams)
                {
                    //using polymorphism with GetComponent, the gameobjects are moved with WASD
                    ally.GetComponent<Transform>().Translate(Vector3.forward * Time.deltaTime * 10f);
                }
            }
            


            if (Input.GetKey(KeyCode.A))
            {
                if (sentryCreatorIsStationed)
                {
                    foreach (GameObject ally in Stations)
                    {
                        //using polymorphism with GetComponent, the gameobjects are moved with WASD
                        ally.GetComponent<Transform>().Translate(-1 * Vector3.right * Time.deltaTime * 10f);
                    }
                }
                else
                {
                    foreach (GameObject ally in Roams)
                    {
                        //using polymorphism with GetComponent, the gameobjects are moved with WASD
                        ally.GetComponent<Transform>().Translate(-1 * Vector3.right * Time.deltaTime * 10f);
                    }
                }
                    
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (sentryCreatorIsStationed)
                {
                    foreach (GameObject ally in Stations)
                    {
                        //using polymorphism with GetComponent, the gameobjects are moved with WASD
                        ally.GetComponent<Transform>().Translate(-1 * Vector3.forward * Time.deltaTime * 10f);
                    }
                }
                else
                {
                    foreach (GameObject ally in Roams)
                    {
                        //using polymorphism with GetComponent, the gameobjects are moved with WASD
                        ally.GetComponent<Transform>().Translate(-1 * Vector3.forward * Time.deltaTime * 10f);
                    }
                }
                
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (sentryCreatorIsStationed)
                {
                    foreach (GameObject ally in Stations)
                    {
                        //using polymorphism with GetComponent, the gameobjects are moved with WASD
                        ally.GetComponent<Transform>().Translate(Vector3.right * Time.deltaTime * 10f);
                    }
                }
                else
                {
                    foreach (GameObject ally in Roams)
                    {
                        //using polymorphism with GetComponent, the gameobjects are moved with WASD
                        ally.GetComponent<Transform>().Translate(Vector3.right * Time.deltaTime * 10f);
                    }
                }
            }


        }
    }*/
}
