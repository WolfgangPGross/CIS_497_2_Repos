using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryMethodPatternWithGameObjects
{
    [System.Serializable]
    public class EnemyZombie : NPC
    {

        public EnemyZombie()
        {
            this.NPCType = "Enemy Zombie";
            this.Allegiance = AllegianceType.ENEMY;
            this.Weapon = "Bite";
            this.Damage = 7;
            this.Speed = 3.0f;
        }
        void OnEnable()
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}