using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryMethodPattern
{
    public class NPCSimulator : MonoBehaviour
    {
        public NPCCreator enemySpawner;
        public NPCCreator allySpawner;
        
        public List<NPC> enemies;
        public List<NPC> allies;

        // Start is called before the first frame update
        void Start()
        {
            enemySpawner = new EnemyCreator();
            allySpawner = new AllyCreator();

            enemies = new List<NPC>();
            allies = new List<NPC>();

            for (int i = 0; i < 2; i++)
            {
                enemies.Add(enemySpawner.SpawnNPC("Zombie"));
            }

            for (int i = 0; i < 2; i++)
            {
                allies.Add(allySpawner.SpawnNPC("Vampire"));
            }



        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                enemies.Add(enemySpawner.SpawnNPC("Zombie"));
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                enemies.Add(enemySpawner.SpawnNPC("Vampire"));
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                enemies.Add(enemySpawner.SpawnNPC("Werewolf"));
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                allies.Add(allySpawner.SpawnNPC("Zombie"));
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                allies.Add(allySpawner.SpawnNPC("Vampire"));
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                allies.Add(allySpawner.SpawnNPC("Werewolf"));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (NPC ally in allies)
                {
                    ally.Attack();
                }

                foreach (NPC enemy in enemies)
                {
                    enemy.Attack();
                }

            }

        }
    }
}