using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryMethodPatternWithGameObjects
{

    public class AllyCreator : NPCCreator
    {
        private GameObject allyPrefab;


        public override GameObject CreateNPCPrefab(string type)
        {

            if (type.Equals("Zombie"))
            {
                allyPrefab = Resources.Load<GameObject>("Capsule");
                //allyPrefab.AddComponent<AllyZombie>();
            }
            else if (type.Equals("Vampire"))
            {
                allyPrefab = Resources.Load<GameObject>("Sphere");
                //allyPrefab.AddComponent<AllyVampire>();
            }
            else if (type.Equals("Werewolf"))
            {
                allyPrefab = Resources.Load<GameObject>("Cube");
                //allyPrefab.AddComponent<AllyWerewolf>();
            }

            return allyPrefab;
        }

        public override GameObject AddNPCScript(GameObject prefab, string type)
        {


            if (type.Equals("Zombie"))
            {

                //If there is not already a Zombie script attached to the prefab, attach one
                if (prefab.GetComponent<AllyZombie>() == null)
                {
                    prefab.AddComponent<AllyZombie>();
                }
            }
            else if (type.Equals("Vampire"))
            {

                //If there is not already a Vampire script attached to the prefab, attach one
                if (prefab.GetComponent<AllyVampire>() == null)
                {
                    prefab.AddComponent<AllyVampire>();
                }

            }
            else if (type.Equals("Werewolf"))
            {

                //If there is not already a Werewolf script attached to the prefab, attach one
                if (prefab.GetComponent<AllyWerewolf>() == null)
                {
                    prefab.AddComponent<AllyWerewolf>();
                }
            }

                return prefab;
        }


    }
}