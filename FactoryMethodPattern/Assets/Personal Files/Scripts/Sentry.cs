using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Wolfgang Gross
 * CIS 497
 * Factory Method Pattern
 */
[System.Serializable]
public class Sentry : MonoBehaviour
{
    public GameObject target;

    //Name of sentry
    public string SentryType;
    
    //Might just make all do full or 1/3 damage
    public int Damage;
    //0-stationary, 1-moving
    public int Behavior;
    //Can be used for either firing speed or movement speed dependent on typing
    public float Speed;

    public bool cooledDown = true;

    private void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Target");
    }

    public void Attack()
    {
        GameObject spawnPrefab;
        
        if (cooledDown)
        {
            cooledDown = false;
            StartCoroutine(cooldown());

            //Fire projectile here
            //Instantiate(,);
            spawnPrefab = Resources.Load<GameObject>("Sphere");
            spawnPrefab.AddComponent<TargetTarget>();
        }
        
        
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(5 / Speed);
        cooledDown = true;
    }

    public void Move()
    {
        if (this.Behavior == 0)
        {
            //Do nothing because stationary
        }
        else if (this.Behavior == 1)
        {
            //this.GetComponent<Transform>().transform.position 
            //Move towards the player

            //Use Speed modifier here
        }
        
    }

    public override string ToString()
    {
        return "SentryType: " + this.SentryType + "\n" +
                  "Damage: " + this.Damage + "\n" + 
                  "Speed: " + this.Speed + "\n" +
                  "Behavior: " + this.Behavior;
    }
}