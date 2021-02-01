/*
 * Wolfgang Gross
 * CIS 497 2
 * HW 1
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InformationDisplay
{
    //Updates display with current health status
    void displayHealth();

    //Updates display with current stat values
    void displayStats();
}