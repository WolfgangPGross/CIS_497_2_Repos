using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    *Wolfgang Gross
    * CIS497 - ObjectPooler Pattern
    * 
    * Helper script
    */

public class Target : MonoBehaviour, IPooledObject
{
    //private GameManager gameManager;

    private Rigidbody targetRb;

    private float minSpeed = 8;
    private float maxSpeed = 14;
    private float maxTorque = 10;

    private float xRange = 4;
    private float ySpawnPos = -6;

    public float lifespan = 0;

    public int pointValue; 

    GameManager gameManager;

    //public ParticleSystem explosionParticle;

    // Changed from Start -> 
    public void OnObjectSpawn()
    {
        gameManager = GameManager.Instance;

        targetRb = GetComponent<Rigidbody>();

        //Set the position with a randomized X value
        transform.position = RandomSpawnPos();

        //Zero out forces
        targetRb.velocity = new Vector3(0,0,0);

        //Add a force upwards multipled by a randomized speed
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        //Add a torque (rotational force) with randomized xyz values
        targetRb.AddTorque(RandomTorque(), RandomTorque(),
            RandomTorque(), ForceMode.Impulse);

        //Set reference to GameManager
        //gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private void OnMouseDown()
    {
        /*if (gameManager.isGameActive)
        {*/
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.UpdateLocalScore(pointValue);

        //Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

        //just set inactive for object pooling
        //Destroy(gameObject);
        //gameObject.SetActive(false);    
        ObjectPooler.Instance.ReturnObjectToPool(gameObject.tag, gameObject);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Unload"))
        {
            //gameManager.GameOver();
            StartCoroutine(DoLifespanTick());
            
        }
        //Destroy(gameObject);
        //gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DoLifespanTick()
    {
        yield return new WaitForSeconds(8f);
        ObjectPooler.Instance.ReturnObjectToPool(gameObject.tag, gameObject);
    }
    
}
