using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryMethodPatternWithGameObjects
{
    [System.Serializable]
    public class NPC : MonoBehaviour
    {
        public string NPCType;
        public enum AllegianceType { ALLY, NEUTRAL, ENEMY }
        public AllegianceType Allegiance;
        public string Weapon;
        public int Damage;
        public float Speed;

        public void Attack()
        {
            if (!Health.GameOver)
            {
                Debug.Log("The " + this.NPCType +
                " attacks with " + this.Weapon +
                         " for " + this.Damage + " damage.");

                if (this.Allegiance == AllegianceType.ALLY)
                {
                    Health.EnemyHealth -= Damage;
                    Debug.Log("Enemy takes " + Damage + " damage.");
                    Debug.Log("Enemy health is now " + Health.EnemyHealth + ".");
                }
                else if (this.Allegiance == AllegianceType.ENEMY)
                {
                    Health.PlayerHealth -= Damage;
                    Debug.Log("You take " + Damage + " damage.");
                    Debug.Log("Your health is now " + Health.EnemyHealth + ".");
                }

                Health.CheckWinLossConditions();
            }
        }

        public void Move()
        {
            if (!Health.GameOver)
            {
                Debug.Log("The " + this.NPCType +
                    " moves at " + this.Speed + " speed.");
            }
        }

        public override string ToString()
        {
            return "EnemyType: " + this.NPCType + "\n" +
                      "Weapon: " + this.Weapon + "\n" +
                      "Damage: " + this.Damage;
        }


    }

}