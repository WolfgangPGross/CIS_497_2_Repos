using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Wolfgang Gross
 * CIS 497
 * Factory Method Pattern
 */
public class SentryStation : SentryCreator
{
    private GameObject sentryPrefab;

    public override GameObject CreateSentryPrefab(string type)
    {
        if (type.Equals("Tank"))
        {
            //Change prefab gameobject
            sentryPrefab = Resources.Load<GameObject>("Capsule");

        }
        else if (type.Equals("Turret"))
        {
            //Change prefab gameobject
            sentryPrefab = Resources.Load<GameObject>("Sphere");

        }

        return sentryPrefab;
    }

    public override GameObject AddSentryScript(GameObject prefab, string type)
    {
        if (type.Equals("Tank"))
        {
            //If there is not already a Zombie script attached to the prefab, attach one
            if (prefab.GetComponent<StationTank>() == null)
            {
                prefab.AddComponent<StationTank>();
            }
        }
        else if (type.Equals("Turret"))
        {
            //If there is not already a Vampire script attached to the prefab, attach one
            if (prefab.GetComponent<StationTurret>() == null)
            {
                prefab.AddComponent<StationTurret>();
            }
        }
        return prefab;
    }
}
