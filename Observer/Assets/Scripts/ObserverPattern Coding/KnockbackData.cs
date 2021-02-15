using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Wolfgang Gross
 * 2021 Spring Semester
 * CIS 497_2
 * 
 * Observer Pattern for dealing with knockback on objects
 */

//Attach this class to an empty GameObject in the scene
public class KnockbackData : MonoBehaviour, ISubject
{
    private List<IObserver> observers = new List<IObserver>();

    private bool firing = false;

    private float forceForwards = 10f;
    private float forceSideways = 10f;
    private float forceVertical = 10f;

    public void RegisterObserver(IObserver observer)
    {
        //Add observer to list of observers
        observers.Add(observer);

        //Updates data for newly added observer
        observer.UpdateData(firing, forceForwards, forceSideways, forceVertical);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            //include data as parameters to UpdateData
            observer.UpdateData(firing, forceForwards, forceSideways, forceVertical);
            Debug.Log("UpdateData was called from Notify Observers");
        }
    }

    public void toggleFiring()
    {
        firing = !firing;
        NotifyObservers();
    }

    public void increaseForceForwards()
    {
        forceForwards += .1F;
        NotifyObservers();
    }

    public void decreaseForceForwards()
    {
        forceForwards -= .1F;
        NotifyObservers();
    }

    public void increaseForceSideways()
    {
        forceSideways += .1F;
        NotifyObservers();
    }

    public void decreaseForceSideways()
    {
        forceSideways -= .1F;
        NotifyObservers();
    }

    public void increaseForceVertical()
    {
        forceVertical += .1F;
        NotifyObservers();
    }

    public void decreaseForceVertical()
    {
        forceVertical -= .1F;
        NotifyObservers();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            toggleFiring();
            Debug.Log("Firing at Orange Object: [" + firing + "]");
        }

        if (Input.GetKey(KeyCode.W))
        {
            increaseForceForwards();
            Debug.Log("Forwards force is now: " + forceForwards);
        }

        if (Input.GetKey(KeyCode.S))
        {
            decreaseForceForwards();
            Debug.Log("Forwards force is now: " + forceForwards);
        }

        if (Input.GetKey(KeyCode.A))
        {
            increaseForceSideways();
            Debug.Log("Sideways force is now: " + forceSideways);
        }

        if (Input.GetKey(KeyCode.D))
        {
            decreaseForceSideways();
            Debug.Log("Sideways force is now: " + forceSideways);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            increaseForceVertical();
            Debug.Log("Vertical force is now: " + forceVertical);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            decreaseForceVertical();
            Debug.Log("Vertical force is now: " + forceVertical);
        }
    }
}