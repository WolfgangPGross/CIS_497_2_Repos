using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidPointSpawn : Spawn
{
    // Start is called before the first frame update
    void Start()
    {
        this.SpawnType = "MidPoint";
        this.SpinSpeed = 10.0f;
        this.PointValue = 10;
    }
}
