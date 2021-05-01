using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Wolfgang Gross
 * CIS 497
 * Factory Method Pattern
 */
public class RoamTank : Sentry
{
    public RoamTank()
    {
        this.SentryType = "RoamTank";
        this.Behavior = 1;
        this.Damage = 10;
        this.Speed = 5.0f;
    }
    void OnEnable()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
