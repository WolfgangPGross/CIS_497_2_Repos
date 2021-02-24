using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{

    [SerializeField] private string textToDisplay;

    public void Display()
    {
        gameObject.GetComponent<Text>().text = textToDisplay;
    }

    public void Display(string text)
    {
        textToDisplay = text;
        Display();
    }

    public void Display(PlayerModifier playerModifier)
    {
        textToDisplay = "";
        textToDisplay += "Player Speed: ";
        textToDisplay += playerModifier.speed;
        textToDisplay += "\n";

        textToDisplay += "Damage: ";
        textToDisplay += playerModifier.damage;
        textToDisplay += "\n";

        textToDisplay += "Knockback: ";
        textToDisplay += playerModifier.knockback;
        textToDisplay += "\n";


        /*textToDisplay += "Modifiers: ";
        textToDisplay += playerModifier.modifiers;
        */
        Display();
    }

}