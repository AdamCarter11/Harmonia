using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;
    public ButtonScript bs;
    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Battle Won") == 0)
        {
            win.SetActive(false);
            lose.SetActive(true);
            credits.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Battle Won") == 1)
        {
            win.SetActive(true);
            lose.SetActive(false);
            credits.SetActive(true);
        }
    }

    public void Continue()
    {
        if (PlayerPrefs.GetInt("Battle Won") == 0)
        {
            bs.NewGame();
            SceneManager.LoadScene("Menu");
        }
        else if (PlayerPrefs.GetInt("Battle Won") == 1)
        {
            PlayerPrefs.SetInt("Battle Won", 0);
            SceneManager.LoadScene("Menu");
        }
    }

    public void removeCredits()
    {
        credits.SetActive(false);
    }
}
