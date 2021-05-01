using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryMethodPattern
{

    public class EnemyCreator : NPCCreator
    {

        public override NPC CreateNPC(string type)
        {
            NPC enemy = null;

            if (type.Equals("Zombie"))
            {
                enemy = new EnemyZombie();
            }
            else if (type.Equals("Vampire"))
            {
                enemy = new EnemyVampire();
            }
            else if (type.Equals("Werewolf"))
            {
                enemy = new EnemyWerewolf();
            }

            return enemy;
        }


    }
}