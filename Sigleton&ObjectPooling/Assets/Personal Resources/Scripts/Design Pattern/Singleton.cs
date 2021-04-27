using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
    *Wolfgang Gross
    * CIS497 - Singleton Pattern
    * 
    * Persists between Instances and carries data along 
    */

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T uniqueInstance;

    public int localScore = 0;
    public List<int> highScores = new List<int>();

    public string currentLevel;
    public bool playing = false;

    public static T Instance
    {
        get { return uniqueInstance; }
    }

    public static bool IsInitialized
    {
        get { return uniqueInstance != null; }
    }

    private void Awake()
    {
        if (uniqueInstance != null)
        {
            Debug.LogError("[Singleton] Trying to instantiate a second instance of a singleton class");
        }
        else
        {
            uniqueInstance = (T)this;
        }
    }

    protected virtual void OnDestroy()
    {
        //if this object is destroyed, make instance null so another can be created
        if (uniqueInstance == this)
        {
            uniqueInstance = null;
        }


    }

}
