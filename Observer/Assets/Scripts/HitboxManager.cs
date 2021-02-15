using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour
{
    public bool player_Hitboxes_Active;

    // Start is called before the first frame update
    void Start()
    {
        player_Hitboxes_Active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(player_Hitboxes_Active)
        {
            //Turn hitboxes on
        }
        else
        {
            //Turn hitboxes off
        }
    }
}
