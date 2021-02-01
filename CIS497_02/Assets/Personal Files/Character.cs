/*
 * Wolfgang Gross
 * CIS 497 2
 * HW 1
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : BaseMoves, InformationDisplay
{
    public float runSpeed;
    public float jumpHeight;
    public float totalHealth;

    //InformationDisplay
    public abstract void displayHealth();
    public abstract void displayStats();

    //BaseMoves
    public abstract void forwardsMovement();
    public abstract void upwardsMovement();

    public void doDeath()
    {
        Debug.Log("Going through object death...");
        //Does cool stuff on death and updates score/conditions
    }
}