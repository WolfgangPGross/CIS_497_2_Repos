using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTargetManager : MonoBehaviour
{
    //Have 8-16 references for directional neighbors
    //Use NSEW for naming conventions
    //Compare between local neighbors and the rotation of the player to determine directions for selecting neighbors as targets
    private GameObject Me_As_Neighbor;

    public GameObject NorthNeighbor;
    public GameObject SouthNeighbor;
    public GameObject EastNeighbor;
    public GameObject WestNeighbor;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Me_As_Neighbor = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            player.transform.position = NorthNeighbor.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.transform.position = SouthNeighbor.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.transform.position = EastNeighbor.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.transform.position = WestNeighbor.transform.position;
        }

    }
}
