using UnityEngine;
using System.Collections;

namespace FactoryMethodPattern
{

    public abstract class NPCCreator
    {

        public abstract NPC CreateNPC(string type);

        public NPC SpawnNPC(string type)
        {
            NPC npc;

            npc = CreateNPC(type);

            //This makes the newly spawned NPC move and attack once
            npc.Move();
            npc.Attack();

            return npc;
        }


    }
}