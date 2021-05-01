using UnityEngine;
using System.Collections;

namespace FactoryMethodPatternWithGameObjects
{

    public abstract class NPCCreator
    {


        public abstract GameObject CreateNPCPrefab(string type);
        public abstract GameObject AddNPCScript(GameObject prefab, string type);


        void Start()
        {

        }

            /*
            // This method is NOT being used 
            // because we want to try instantiating the object 
            // before we add the script
            public GameObject OrderNPC(string type)
            {
            GameObject npc;

            npc = CreateNPCPrefab(type);

            npc = AddNPCScript(npc, type);

            //This makes the newly spawned NPC move and attack once
            npc.GetComponent<NPC>().Move();
            npc.GetComponent<NPC>().Attack();

            return npc;
            }*/


    }
}