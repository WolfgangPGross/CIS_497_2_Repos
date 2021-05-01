using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Wolfgang Gross
 * CIS 497
 * Factory Method Pattern
 */
public class RoamTurret : Sentry
{
    public RoamTurret()
    {
        this.SentryType = "RoamTurret";
        this.Behavior = 1;
        this.Damage = 5;
        this.Speed = 3.0f;
    }
    void OnEnable()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
    }
}
