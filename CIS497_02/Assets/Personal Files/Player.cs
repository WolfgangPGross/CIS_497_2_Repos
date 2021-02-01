/*
 * Wolfgang Gross
 * CIS 497 2
 * HW 1
 * 
 */
using System.Collections;
using UnityEngine;

public class Player : Character
{
    private float currentHealth;
    public Player()
    {
        runSpeed = 10f;
        jumpHeight = 10f;
        totalHealth = 100f;
        currentHealth = totalHealth;
    }

    public override void displayHealth()
    {
        //Updates Player display with current health status
        Debug.Log("Player's: 'displayHealth' Method");
    }

    public override void displayStats()
    {
        //Updates Player display with current stat values
        Debug.Log("Player's: 'displayStats' Method");
    }

    public override void forwardsMovement()
    {
        //Performs Player's upwards Movement option
        Debug.Log("Player's: 'forwardsMovement' Method");
    }

    public override void upwardsMovement()
    {
        //Performs Player's forwards Movement option
        Debug.Log("Player's: 'upwardsMovement' Method");
    }
}