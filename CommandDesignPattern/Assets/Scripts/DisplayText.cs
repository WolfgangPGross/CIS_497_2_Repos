using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    public GameObject RewindImage;
    public GameObject RewindXMark;

    public GameObject howToRewind;

    public void toggleRewindImage(bool onOrOff)
    {
        RewindImage.SetActive(onOrOff);
    }

    public void toggleRewindXMark(bool onOrOff)
    {
        RewindXMark.SetActive(onOrOff);
    }

    private void toggleHowToPanel(bool onOrOff)
    {
        howToRewind.SetActive(onOrOff);
    }

    private void Update()
    {
        if (gameObject.transform.position.y <= 0)
        {
            toggleHowToPanel(true);
        }
        else
        {
            if (howToRewind.activeSelf)
            {
                toggleHowToPanel(false);
            }
        }
        if (Input.GetKey(KeyCode.R))
        {
            if (RewindImage.activeSelf == false)
            {
                toggleRewindImage(true);
            }

        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            if (RewindImage.activeSelf == true)
            {
                toggleRewindImage(false);
            }
            //If its active, set X Mark inactive
            if (true)
            {

            }
        }
    }
}
