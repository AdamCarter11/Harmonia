using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Text txt;
    void Update()
    {
        if (PlayerPrefs.GetString("current scene") == "Menu" || PlayerPrefs.GetString("current scene") == "")
        {
            txt.text = "Start";
        }
        else
        {
            txt.text = "Continue";
        }
    }
}
