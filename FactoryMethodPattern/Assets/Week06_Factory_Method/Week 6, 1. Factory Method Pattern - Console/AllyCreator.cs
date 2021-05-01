using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryMethodPattern
{

    public class AllyCreator : NPCCreator
    {

        public override NPC CreateNPC(string type)
        {
            NPC ally = null;

            if (type.Equals("Zombie"))
            {
                ally = new AllyZombie();
            }
            else if (type.Equals("Vampire"))
            {
                ally = new AllyVampire();
            }
            else if (type.Equals("Werewolf"))
            {
                ally = new AllyWerewolf();
            }

            return ally;
        }


    }
}