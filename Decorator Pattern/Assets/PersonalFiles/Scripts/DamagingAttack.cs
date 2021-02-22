using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingAttack : MonoBehaviour
{
    //Damage Assocciated with the attack
    public float damage;

    //Knockback Assocciated with the attack
    //Handle knockback effect on objects in this script
    public float knockback_Strength;

    //Angle that the attack sends the recipient, possibly make a list to have additive/multiplicative launch angles
    public Vector3 knockback_Angle; 

    //Public variables for setting 'knockback_Angle'
    //public float Angle_Right; //x //Just do straight forwards
    //public float Angle_Upwards = 6f; //y
    //public float Angle_Forwards = 3f; //z

    //Who to apply to
    private int whoToDamage;

    //Test measure for triggering zones only once
    public bool alreadyTriggeredSomething = false;

    //Create Reference to Percent Tracker
    public PercentGauge percentGauge;

    public DamagingAttack(float damageValue, float knockbackValue)
    {
        damage = damageValue;
        knockback_Strength = knockbackValue;
    }

    void Start()
    {
        //Initialize reference to Percent Tracker
        percentGauge = GameObject.FindObjectOfType<PercentGauge>();

        knockback_Angle = new Vector3(0, 6f, 3f);
    }

    //Both objects need rigidbodies and colliders
    private void OnTriggerEnter(Collider other)
    {
        if (alreadyTriggeredSomething == false)
        {
            string collisionName = other.name;

            if (collisionName == "Player-1" || collisionName == "Player-2")
            {
                alreadyTriggeredSomething = true;
                Debug.Log("[ " + this.name + " ] - OBJECT entered TriggerZone: " + collisionName);



                //Check to see who to deal damage to
                string playerCheck = collisionName.Substring(collisionName.Length - 1);
                Debug.Log("Player # Check: [ " + playerCheck + " ]");

                int whoToDamage = 0;

                if (playerCheck == "1")
                {
                    //Debug.Log("whoToDamage set to [1]");
                    whoToDamage = 1;

                    //Logic behind damage
                    //Debug.Log("Attempting to deal damage to: " + other.name);
                    percentGauge.DealDamage(damage, whoToDamage);
                }
                else if (playerCheck == "2")
                {
                    //Debug.Log("whoToDamage set to [2]");
                    whoToDamage = 2;

                    //Logic behind damage
                    //Debug.Log("Attempting to deal damage to: " + other.name);
                    percentGauge.DealDamage(damage, whoToDamage);
                }

                //Logic behind knockback
                //Debug.Log("Attempting to addForce to: " + collision.gameObject.name);
                Vector3 passedKnockback = gameObject.transform.TransformDirection(knockback_Angle);

                /*Debug.Log("Knockback Method Call Parameters, knockback: [" + knockback_Strength + "], " +
                    "attackDirection: [" + tempVector2 + "], attackOrigin: [" + gameObject.transform
                    + "], toWhichPlayer: [" + whoToDamage + "]");
                    */

                percentGauge.DealKnockback(knockback_Strength, passedKnockback, gameObject.transform, whoToDamage);

                //destroy projectile
                Destroy(gameObject);
            }
        }
    }
}