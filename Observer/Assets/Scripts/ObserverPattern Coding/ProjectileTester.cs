using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this class to the barrel of a cannon prefab
public class ProjectileTester : MonoBehaviour, IObserver
{
    private bool firing;
    private float forceForwards;
    private float forceSideways;
    private float forceVertical;

    //Attach the GameObject holding ForceData to this in the inspector
    public KnockbackData KnockbackData;

    //Attach the cannonball prefab "core" to this in the the inspector
    public Rigidbody projectile;

    /*public GameObject Player1;
    public GameObject Player2;*/

    public void UpdateData(bool firing, float forceForwards, float forceSideways, float forceVertical)
    {
        if (this.firing != firing)
        {
            this.firing = firing;
            UpdateFiring();
        }

        this.forceForwards = forceForwards;
        this.forceSideways = forceSideways;
        this.forceVertical = forceVertical;
    }

    void Start()
    {
        KnockbackData.RegisterObserver(this);
    }

    void UpdateFiring()
    {
        if (firing)
        {
            InvokeRepeating("LaunchProjectile", 0.2f, 2.0f);
        }
        else
        {
            CancelInvoke();
        }
    }

    void LaunchProjectile()
    {
        Rigidbody instance = Instantiate(projectile, transform.position, transform.rotation);

        instance.AddForce(transform.forward * 2f, ForceMode.Impulse);

        //instance.GetComponent<FlyAtTarget>().changeTarget(Player1);

        instance.GetComponent<DamagingAttack>().UpdateData(firing, forceForwards, forceSideways, forceVertical);
    }
}