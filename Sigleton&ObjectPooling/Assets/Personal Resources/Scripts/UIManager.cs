using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    *Wolfgang Gross
    * CIS497 - ObjectPooler Pattern
    * 
    * Ease of use scripts
    */

public class UIManager : MonoBehaviour
{
    //public Text PreviousScore;
    public Text HighScore;
    public Text LocalScore;
    public GameObject pauseMenu;
    public GameObject startMenu;

    public void toggleLocalText(bool toWhat)
    {
        LocalScore.gameObject.SetActive(toWhat);
    }

    public void UpdateLocal(int score)
    {
        LocalScore.text = "Score: " + score;
    }

    public void toggleHighText(bool toWhat)
    {
        HighScore.gameObject.SetActive(toWhat);
        
    }

    public void UpdateHigh(int score)
    {
        HighScore.text = "HighScore: " + score;
    }

    public void togglePause(bool whatTo)
    {
        pauseMenu.SetActive(whatTo);
    }

    public void toggleStart(bool whatTo)
    {
        startMenu.SetActive(whatTo);
    }
}
