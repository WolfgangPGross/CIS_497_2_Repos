/*
 * Wolfgang Gross
 * CIS 497 2
 * HW 1
 * 
 */
using System.Collections;
using UnityEngine;

public class Computer : Character
{
    private float currentHealth;
    public Computer()
    {
        runSpeed = 8f;
        jumpHeight = 8f;
        totalHealth = 50f;
        currentHealth = totalHealth;
    }

    public override void displayHealth()
    {
        //Updates Computer display with current health status
        Debug.Log("Computer's: 'displayHealth' Method");
    }

    public override void displayStats()
    {
        //Updates Computer display with current stat values
        Debug.Log("Computer's: 'displayStats' Method");
    }

    public override void forwardsMovement()
    {
        //Performs Computer's upwards Movement option
        Debug.Log("Computer's: 'forwardsMovement' Method");
    }

    public override void upwardsMovement()
    {
        //Performs Computer's forwards Movement option
        Debug.Log("Computer's: 'upwardsMovement' Method");
    }
}