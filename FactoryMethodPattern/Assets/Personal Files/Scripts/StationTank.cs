using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Wolfgang Gross
 * CIS 497
 * Factory Method Pattern
 */
public class StationTank : Sentry
{
    public StationTank()
    {
        this.SentryType = "StationTank";
        this.Behavior = 0;
        this.Damage = 15;
        this.Speed = 1.0f;
    }
    void OnEnable()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
