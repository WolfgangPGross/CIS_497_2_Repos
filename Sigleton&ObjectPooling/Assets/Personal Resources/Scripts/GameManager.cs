using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
/*
    *Wolfgang Gross
    * CIS497 - Singleton Pattern
    * 
    * Helper script to access Instances appropriately
    */

public class GameManager : Singleton<GameManager>
{
    public UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void UpdateLocalScore(int scoreUpdate)
    {
        Instance.localScore += scoreUpdate;
        
        if (Instance.localScore < 0)
        {
            Instance.localScore = 0;
        }

        uiManager.UpdateLocal(localScore);
    }

    public void UpdateHighScore() 
    {
        if (Instance.highScores.Count < 1)
        {
            uiManager.UpdateHigh(0);
        }
        else
        {
            uiManager.UpdateHigh(Instance.highScores.Max());
        }
    }

    public void pushScore()
    {
        if (Instance.localScore > 0)
        {
            Instance.highScores.Add(localScore);
            //highScores.Add(localScore);
            /*if(localScore > highScore)
            {
                highScore = localScore;
            }*/

            Instance.localScore = 0;
            UpdateHighScore();
            UpdateLocalScore(0);
        }
    }

    public void togglePlaying(bool whatTo)
    {
        Instance.playing = whatTo;
    }

    //methods to load and unload scenes
    public void LoadLevel(string levelName)
    {

        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }
        //CurrentLevelName = levelName;
        Instance.currentLevel = levelName;
    }

    public void UnLoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + levelName);
            return;
        }

        //Logic for scores
        if(Instance.localScore > 0)
        {
            Instance.highScores.Add(localScore);
            //highScores.Add(localScore);
            /*if(localScore > highScore)
            {
                highScore = localScore;
            }*/

            Instance.localScore = 0;
            UpdateHighScore();
            UpdateLocalScore(0);
        }
    }

    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(currentLevel);
        string temp = currentLevel;

        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + temp);
            return;
        }
        //Logic for scores
        else
        {
            if (temp == "MainMenu")
            {
                uiManager.toggleHighText(false);
                uiManager.toggleHighText(true);
            }
            else if (temp == "PlayableLevel")
            {
                uiManager.toggleHighText(true);
                uiManager.toggleHighText(false);
            }
            if (Instance.localScore > 0)
            {
                Instance.highScores.Add(Instance.localScore);

                Instance.localScore = 0;
                UpdateHighScore();
                UpdateLocalScore(0);
            }
        }
    }

    //pausing and unpausing

    public void Pause()
    {
        Time.timeScale = 0f;
        uiManager.togglePause(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        uiManager.togglePause(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Instance.playing)
            {
                Pause();
            }
            
        }

    }

}
