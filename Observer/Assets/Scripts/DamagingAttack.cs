using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingAttack : MonoBehaviour, IObserver
{
    //Damage Assocciated with the attack
    public float damage;

    //Knockback Assocciated with the attack
    //Handle knockback effect on objects in this script
    public float knockback_Strength;
    
    //Angle that the attack sends the recipient, possibly make a list to have additive/multiplicative launch angles
    private Vector3 knockback_Angle; 

    //Public variables for setting 'knockback_Angle'
    public float Angle_Right; //x
    public float Angle_Forwards; //z
    public float Angle_Upwards; //y
    
    //Directional Modifiers for knockback logic
    private int Multiplier_RL = 1; //Right/Left direction modifier
    private int Multiplier_UD = 1; //Up/Down direction modifier
    private int Multiplier_FB = 1; //Forward/Back direction modifier

    //Actor Assocciated with the attack
    public string attacker;

    //Who to apply to
    private int whoToDamage;

    //Need reference to this gameObject's collider
    //private SphereCollider personalCollider; //-Might need to change if using different than sphere colliders

    //Test measure for triggering zones only once
    public bool alreadyTriggeredSomething = false;

    //Create Reference to Percent Tracker
    //private GameObject PercentTracker;
    public PercentGauge percentGauge;

    public KnockbackData knockbackData;

    // Start is called before the first frame update
    void Start()
    {
        knockbackData = FindObjectOfType<KnockbackData>();

        knockbackData.RegisterObserver(this);

        //Initialize reference to Percent Tracker
        //PercentTracker = GameObject.FindGameObjectWithTag("PercentTracker");
        percentGauge = GameObject.FindObjectOfType<PercentGauge>();
        //personalCollider = GetComponent<SphereCollider>();
        
        //Debug.Log(Angle_Right + " " +  Multiplier_RL + " " + Angle_Upwards + " " + Multiplier_UD + " " + Angle_Forwards + " " + Multiplier_FB);
        knockback_Angle = new Vector3(Angle_Right * Multiplier_RL, Angle_Upwards * Multiplier_UD, Angle_Forwards * Multiplier_FB);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Both objects need rigidbodies and colliders
    private void OnTriggerEnter(Collider other)
    {
        if(alreadyTriggeredSomething == false)
        {
            alreadyTriggeredSomething = true; //-Might be able to hit mutliple things in the future before being turned off
            Debug.Log("[ " + this.name + " ] - OBJECT entered TriggerZone: " + other.name);

            //Do check that trigger is not from the player who cast it
            //--DO THIS AFTER GET THE REST OF MECHANIC WORKING
            
            string collisionName = other.name;

            //Check to see who to deal damage to
            string playerCheck = collisionName.Substring(collisionName.Length - 1);
            Debug.Log("Player # Check: [ " + playerCheck + " ]");

            //Check what kind of hitbox was triggered
            string hitboxCheck = collisionName.Substring(0, 5);
            Debug.Log("Hitbox type Check: [ " + hitboxCheck + " ]");

            int whoToDamage = 0;

            if (playerCheck == "1")
            {
                //Debug.Log("whoToDamage set to [1]");

                whoToDamage = 1;

                //Logic behind damage
                if (hitboxCheck == "Basic")
                {
                    //Debug.Log("Attempting to deal damage to: " + other.name);
                    percentGauge.DealDamage(damage, whoToDamage); //--Fix Indicator in method for who to damage
                }
                else if (hitboxCheck == "Criti")
                {
                    //Debug.Log("Attempting to deal damage to: " + other.name);
                    percentGauge.DealDamage(damage * (1.25f), whoToDamage); //--Fix Indicator in method for who to damage
                }

            }
            else if (playerCheck == "2")
            {
                //Debug.Log("whoToDamage set to [2]");

                whoToDamage = 2;

                //Logic behind damage
                if (hitboxCheck == "Basic")
                {
                    //Debug.Log("Attempting to deal damage to: " + other.name);
                    percentGauge.DealDamage(damage, whoToDamage); //--Fix Indicator in method for who to damage
                }
                else if (hitboxCheck == "Criti")
                {
                    //Debug.Log("Attempting to deal damage to: " + other.name);
                    percentGauge.DealDamage(damage * (1.25f), whoToDamage); //--Fix Indicator in method for who to damage
                }

                
            }

            //Logic behind knockback
            //Debug.Log("Attempting to addForce to: " + collision.gameObject.name);

            Vector3 tempVector2 = gameObject.transform.TransformDirection(knockback_Angle); //-New Implementation

            /*Debug.Log("Knockback Method Call Parameters, knockback: [" + knockback_Strength + "], " +
                "attackDirection: [" + tempVector2 + "], attackOrigin: [" + gameObject.transform
                + "], toWhichPlayer: [" + whoToDamage + "]");
                */

            percentGauge.DealKnockback(knockback_Strength, tempVector2, gameObject.transform, whoToDamage);

            //Check if is a projectile, if is, destroy projectile --Put at end of logic
            if (GetComponent<FlyAtTarget>())
            {
                knockbackData.RemoveObserver(this);

                Destroy(gameObject);
            }
        }
        
        //Destroy(personalCollider);
        //personalCollider.isTrigger = false;
        //Disable collider ^^^
    }

    //Functions to affect direction of knockback axis'
    public void Mirror_Knockback_RL()
    {
        //Debug.Log("Mirroring knockback on [ " + gameObject.name + " ] for direction [ Right-Left ]");
        Multiplier_RL *= (-1);
    }
    public void Mirror_Knockback_UD()
    {
        //Debug.Log("Mirroring knockback on [ " + gameObject.name + " ] for direction [ Up-Down ]");
        Multiplier_UD *= (-1);
    }
    public void Mirror_Knockback_FB()
    {
        //Debug.Log("Mirroring knockback on [ " + gameObject.name + " ] for direction [ Forward-Back ]");
        Multiplier_FB *= (-1);
    }

    public void UpdateData(bool firing, float forceForwards, float forceSideways, float forceVertical)
    {
        Angle_Right = forceSideways;
        Angle_Forwards = forceForwards;
        Angle_Upwards = forceVertical;
    }

    /*
    //Collision bad for some attacks since it impacts its own physics
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        //Need to also check that it is not from the person who attacked //Later
        if (collision.gameObject.name == "Player 1")
        {
            //Handle knockback here
            //If what collided with has a rigidbody, add force in specified direction with specified knockback
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Debug.Log("Attempting to addForce to: " + collision.gameObject.name);
            //enemyRigidbody.AddForce(transform.right * knockback, ForceMode.Impulse);

            //!!!!!!!!!!!NEW TO THIS SESSION!!!!!!!!!!!
            Vector3 tempVector = gameObject.transform.right;

            percentGauge.DealKnockback(knockback_Strength, tempVector, 1);

            //Have PercentGauge handle damage for tracker
            //better track who to deal damage to
            Debug.Log("Attempting to deal damage to: " + collision.gameObject.name);
            percentGauge.DealDamage(damage, 1);

            Debug.Log("Destroying Projectile...");
            //Destory the Attack hitbox on impact //Later possibly disable hitbox
            Destroy(gameObject);
        }
        //Need to also check that it is not from the person who attacked //Later
        if (collision.gameObject.name == "Player 2")
        {
            //Handle knockback here
            //If what collided with has a rigidbody, add force in specified direction with specified knockback
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Debug.Log("Attempting to addForce to: " + collision.gameObject.name);
            //enemyRigidbody.AddForce(transform.right * knockback, ForceMode.Impulse);

            ///!!!!!!!NEW TO THIS SESSION!!!!!!!!!!!!
            Vector3 tempVector = gameObject.transform.right;

            percentGauge.DealKnockback(knockback_Strength, tempVector, 2);

            //Have PercentGauge handle damage for tracker
            //better track who to deal damage to
            Debug.Log("Attempting to deal damage to: " + collision.gameObject.name);
            percentGauge.DealDamage(damage, 2);

            Debug.Log("Destroying Projectile...");
            //Destory the Attack hitbox on impact //Later possibly disable hitbox
            Destroy(gameObject);
        }
    }*/
}
