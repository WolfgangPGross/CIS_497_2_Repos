/*
 * Wolfgang Gross
 * CIS 497 2
 * HW 1
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : MonoBehaviour
{
        
    public Character character;
    public Character[] enemies = new Character[5];
    public List<Character> characterList = new List<Character>();
    public List<BaseMoves> BaseMovesList = new List<BaseMoves>();
    public List<InformationDisplay> InfoDispList = new List<InformationDisplay>();
    

    void Start()
    {        
        //Part 2: a polymorphic array of enemies each die
        enemies[0] = new Computer();
        enemies[1] = new Computer();
        enemies[2] = new Player();
        enemies[3] = new Player();
        enemies[4] = new NPC();

            foreach (Character enemy in enemies)
            {
                if (enemy == null) { break; }
                enemy.displayHealth();
                enemy.displayStats();
                enemy.forwardsMovement();
                enemy.upwardsMovement();
                enemy.doDeath();
            }

            //Part 3: a polymorphic list of enemies each die

            //Add 4 enemies to the list
            for (int i = 0; i < 2; i++)
            {
                characterList.Add(new Computer());
                characterList.Add(new Player());
            }
            characterList.Add(new NPC());

            //Remove enemy at index position 8
            //characterList.RemoveAt(8);

            //Remove the 3 enemies at positions 6-7
            //characterList.RemoveRange(6, 2);

            /*foreach (Character enemy in characterList)
            {
                if (enemy == null) { break; }
            //enemy.doDeath();
            enemy.displayHealth();
            }*/

            //Part 4: a polymorphic list of enemies that have moves and info display

            for (int i = 0; i < 2; i++)
            {
                BaseMovesList.Add(new Computer());
                BaseMovesList.Add(new Player());
            }
        BaseMovesList.Add(new NPC());

            for (int i = 0; i < 2; i++)
            {
                InfoDispList.Add(new Computer());
                InfoDispList.Add(new Player());
            }
        InfoDispList.Add(new NPC());

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (Character enemy in characterList)
            {
                if (enemy == null) { break; }
                enemy.forwardsMovement();
                enemy.upwardsMovement();
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (InformationDisplay hasInfo in InfoDispList)
            {
                if (hasInfo == null) { break; }
                hasInfo.displayHealth();
                hasInfo.displayStats();
            }
        }
    }
}