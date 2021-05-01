using UnityEngine;
using System.Collections;

namespace FactoryMethodPatternWithGameObjects
{
    public static class Health
    {
        public static int PlayerHealth = 100;
        public static int EnemyHealth = 100;
        public static bool GameOver = false;

        public static void CheckWinLossConditions()
        {
            Debug.Log("Checking win/loss conditions.");
            Debug.Log("Your health is now " + Health.PlayerHealth + ".");
            Debug.Log("Enemy health is now " + Health.EnemyHealth + ".");

            if (PlayerHealth <= 0)
            {
                Debug.Log("You Lose!");
                GameOver = true;
            }
            else if (EnemyHealth <= 0)
            {
                Debug.Log("You Win!");
                GameOver = true;
            }

            //Could add a method call here
            //to handle allowing game restart here if GameOver == true

        }

    }
}