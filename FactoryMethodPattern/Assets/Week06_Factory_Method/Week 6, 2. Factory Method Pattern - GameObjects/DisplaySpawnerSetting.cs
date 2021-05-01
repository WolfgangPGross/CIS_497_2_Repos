using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FactoryMethodPatternWithGameObjects
{
    public class DisplaySpawnerSetting : MonoBehaviour
    {
        public GameObject NPCSpawner;
        public NPCSpawner NPCSpawnerScriptInstance;

        // Start is called before the first frame update
        void Start()
        {
            NPCSpawnerScriptInstance = NPCSpawner.GetComponent<NPCSpawner>();
        }

        // Update is called once per frame
        void Update()
        {
            string textToDisplay = "";
            if (NPCSpawnerScriptInstance.npcCreatorIsAlly)
            {
                textToDisplay = "Spawner Setting: Ally";
            }
            else if (!NPCSpawnerScriptInstance.npcCreatorIsAlly)
            {
                textToDisplay = "Spawner Setting: Enemy";
            }

            gameObject.GetComponent<Text>().text = textToDisplay;

        }
    }
}