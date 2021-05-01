using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FactoryMethodPatternWithGameObjects
{
    public class DisplayHealth : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            string textToDisplay = "Player Health: " + Health.PlayerHealth.ToString() + "\n" +
                       "Enemy Health: " + Health.EnemyHealth.ToString();

            gameObject.GetComponent<Text>().text = textToDisplay;
        }

        void Update()
        {
            string textToDisplay = "Player Health: " + Health.PlayerHealth.ToString() + "\n" +
                       "Enemy Health: " + Health.EnemyHealth.ToString();

            if (Health.GameOver && Health.PlayerHealth <= 0)
            {
                textToDisplay += "\nGame Over! You Lose!";
            }
            else if (Health.GameOver && Health.EnemyHealth <= 0)
            {
                textToDisplay += "\nGame Over! You Win!";
            }


            gameObject.GetComponent<Text>().text = textToDisplay;

        }
    }
}