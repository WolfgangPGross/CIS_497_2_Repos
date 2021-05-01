using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Wolfgang Gross
 * CIS 497
 * Factory Method Pattern
 */
public abstract class SentryCreator
{
    public abstract GameObject CreateSentryPrefab(string type);
    public abstract GameObject AddSentryScript(GameObject prefab, string type);


    void Start()
    {

    }
}
