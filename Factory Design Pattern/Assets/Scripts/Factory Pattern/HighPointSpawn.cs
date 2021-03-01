using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighPointSpawn : Spawn
{
    // Start is called before the first frame update
    void Start()
    {
        this.SpawnType = "HighPoint";
        this.SpinSpeed = 5.0f;
        this.PointValue = 20;
    }
}
