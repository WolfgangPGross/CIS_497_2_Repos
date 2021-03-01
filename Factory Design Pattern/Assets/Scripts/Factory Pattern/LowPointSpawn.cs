using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPointSpawn : Spawn
{
    // Start is called before the first frame update
    void Start()
    {
        this.SpawnType = "LowPoint";
        this.SpinSpeed = 15.0f;
        this.PointValue = 5;
    }
}
