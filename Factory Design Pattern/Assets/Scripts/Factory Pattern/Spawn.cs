using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    Rigidbody rigidbody;
    private float minSpeed = 12;
    private float maxSpeed = 16;

    protected string SpawnType { get; set; }
    protected int PointValue { get; set; }
    protected float SpinSpeed { get; set; }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        Vector3 speedVector = Vector3.up* Random.Range(minSpeed, maxSpeed);
        rigidbody.AddForce(speedVector, ForceMode.Impulse);
    }
    public void Die()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.UpdateScore(PointValue);
    }

    public void Spin()
    {
        float RandomTorque_x = Random.Range(-SpinSpeed, SpinSpeed);
        float RandomTorque_y = Random.Range(-SpinSpeed, SpinSpeed);
        float RandomTorque_z = Random.Range(-SpinSpeed, SpinSpeed);

        //Add a torque (rotational force) with randomized xyz values
        rigidbody.AddTorque(RandomTorque_x, RandomTorque_y,
            RandomTorque_z, ForceMode.Impulse);
    }

    public override string ToString()
    {
        return "SpawnType: " + this.SpawnType + "\n" +
                  "PointValue: " + this.PointValue + "\n" +
                  "SpinSpeed: " + this.SpinSpeed;
    }
}
