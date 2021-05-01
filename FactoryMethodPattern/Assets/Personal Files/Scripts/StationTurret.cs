using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Wolfgang Gross
 * CIS 497
 * Factory Method Pattern
 */
public class StationTurret : Sentry
{
    public StationTurret()
    {
        this.SentryType = "StationTurret";
        this.Behavior = 0;
        this.Damage = 12;
        this.Speed = 3.0f;
    }
    void OnEnable()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
    }
}