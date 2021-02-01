/*
 * Wolfgang Gross
 * CIS 497 2
 * HW 1
 * 
 */
using System.Collections;
using UnityEngine;

public class NPC : Character
{
    private float currentHealth;
    public NPC()
    {
        runSpeed = 0f;
        jumpHeight = 1f;
        totalHealth = 10000f;
        currentHealth = totalHealth;
    }

    public override void displayHealth()
    {
        //Updates Player display with current health status
        Debug.Log("NPC's: 'displayHealth' Method");
    }

    public override void displayStats()
    {
        //Updates Player display with current stat values
        Debug.Log("NPC's: 'displayStats' Method");
    }

    public override void forwardsMovement()
    {
        //Performs Player's upwards Movement option
        Debug.Log("NPC's: 'forwardsMovement' Method");
    }

    public override void upwardsMovement()
    {
        //Performs Player's forwards Movement option
        Debug.Log("NPC's: 'upwardsMovement' Method");
    }
}