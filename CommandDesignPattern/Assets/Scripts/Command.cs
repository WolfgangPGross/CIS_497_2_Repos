using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Wolfgang Gross
 * CIS 497 2
 * 
 * Command Design Pattern
 * 
 * Command
 * */

public interface Command
{
    void Execute();
    void Undo();
}