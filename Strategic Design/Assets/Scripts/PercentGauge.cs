using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PercentGauge : MonoBehaviour
{
    //Text for 2 fighting players health gauges
    public TextMeshProUGUI player_01_Percent_Text;
    public TextMeshProUGUI player_02_Percent_Text;

    //Float values for player health percentages
    private float player_01_Percent_Value;
    private float player_02_Percent_Value;

    //Reference of both player objects to then get rigidbody and transform of
    public GameObject player_01_gameobject;
    public GameObject player_02_gameobject;

    //References to both player's rigidbodys
    public Rigidbody player_01_rigidbody;
    public Rigidbody player_02_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //Color32 in RGB and O - Opacity
        player_01_Percent_Text.faceColor = new Color32(201, 109, 0, 255);
        player_02_Percent_Text.faceColor = new Color32(0, 119, 255, 255);

        //Temporary Health values for 100-0 play
        player_01_Percent_Value = 100.0f;
        player_02_Percent_Value = 100.0f;

    }

    // Update is called once per frame
    void Update()
    {
        //Updates to current health for players (adds one decimal place)
        player_01_Percent_Text.SetText(player_01_Percent_Value.ToString("F1") + "%");
        player_02_Percent_Text.SetText(player_02_Percent_Value.ToString("F1") + "%");

        if(player_01_Percent_Value < 0)
        {
            Destroy(player_01_gameobject);
            //yield return WaitForSeconds(2f);
            Destroy(player_01_Percent_Text);
        }
        if (player_02_Percent_Value < 0)
        {
            Destroy(player_02_gameobject);
            Destroy(player_02_Percent_Text);
        }
    }

    public void DealDamage(float damage, int toWhichPlayer)
    {
        Debug.Log("Damage dealt : " + damage + ", towards player_0" + toWhichPlayer);

        if (toWhichPlayer == 1) //If player_01
        {
            //Deal damage to player_01
            player_01_Percent_Value -= damage;

        }
        else if (toWhichPlayer == 2) //If player_02
        {
            //Deal damage to player_02
            player_02_Percent_Value -= damage;

        }
    }

    public void DealKnockback(float knockback, Vector3 attackDirection, Transform attackOrigin, int toWhichPlayer)
    {
        Debug.Log("Knockback dealt : " + knockback + ", towards player_0" + toWhichPlayer);

        if (toWhichPlayer == 1) //If player_01
        {
            //Handle knockback here
            //affect rigidbody of player 1    
            player_01_rigidbody.AddForce(attackDirection * knockback * .25f, ForceMode.Impulse);
        
        }
        else if (toWhichPlayer == 2) //If player_02
        {
            //Handle knockback here
            //affect rigidbody of player 2    
            player_02_rigidbody.AddForce(attackDirection * knockback * .25f, ForceMode.Impulse);
        
        }
    }

}
