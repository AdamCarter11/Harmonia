using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    public GameObject Tip1;
    public GameObject Tip2;
    public GameObject Tip3;
    public GameObject Tip4;
    public GameObject Credits;
    public GameObject NoTips;
    public GameObject NextTip;
    public GameObject PrevTip;
    private int whichTip;
    // Start is called before the first frame update
    void Start()
    {
        whichTip = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Game Beaten") == 1)
        {
            NoTips.SetActive(false);
            if (whichTip == 1)
            {
                Tip1.SetActive(true);
                Tip2.SetActive(false);
                Tip3.SetActive(false);
                Tip4.SetActive(false);
                Credits.SetActive(false);
                PrevTip.SetActive(false);
            }
            else if (whichTip == 2)
            {
                Tip1.SetActive(false);
                Tip2.SetActive(true);
                Tip3.SetActive(false);
                Tip4.SetActive(false);
                Credits.SetActive(false);
                PrevTip.SetActive(true);
            }
            else if (whichTip == 3)
            {
                Tip1.SetActive(false);
                Tip2.SetActive(false);
                Tip3.SetActive(true);
                Tip4.SetActive(false);
                Credits.SetActive(false);
            }
            else if (whichTip == 4)
            {
                Tip1.SetActive(false);
                Tip2.SetActive(false);
                Tip3.SetActive(false);
                Tip4.SetActive(true);
                Credits.SetActive(false);
                NextTip.SetActive(true);
            }
            else if (whichTip == 5)
            {
                Tip1.SetActive(false);
                Tip2.SetActive(false);
                Tip3.SetActive(false);
                Tip4.SetActive(false);
                Credits.SetActive(true);
                NextTip.SetActive(false);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("tips_amt") == 1)
            {
                NoTips.SetActive(false);
                if (whichTip == 1)
                {
                    Tip1.SetActive(true);
                    Tip2.SetActive(false);
                    Tip3.SetActive(false);
                    Tip4.SetActive(false);
                    PrevTip.SetActive(false);
                    NextTip.SetActive(false);
                }
            }
            else if (PlayerPrefs.GetInt("tips_amt") == 2)
            {
                NoTips.SetActive(false);
                if (whichTip == 1)
                {
                    Tip1.SetActive(true);
                    Tip2.SetActive(false);
                    Tip3.SetActive(false);
                    Tip4.SetActive(false);
                    PrevTip.SetActive(false);
                    NextTip.SetActive(true);
                }
                else if (whichTip == 2)
                {
                    Tip1.SetActive(false);
                    Tip2.SetActive(true);
                    Tip3.SetActive(false);
                    Tip4.SetActive(false);
                    PrevTip.SetActive(true);
                    NextTip.SetActive(false);
                }
            }
            else if (PlayerPrefs.GetInt("tips_amt") == 3)
            {
                NoTips.SetActive(false);
                if (whichTip == 1)
                {
                    Tip1.SetActive(true);
                    Tip2.SetActive(false);
                    Tip3.SetActive(false);
                    Tip4.SetActive(false);
                    PrevTip.SetActive(false);
                    NextTip.SetActive(true);
                }
                else if (whichTip == 2)
                {
                    Tip1.SetActive(false);
                    Tip2.SetActive(true);
                    Tip3.SetActive(false);
                    Tip4.SetActive(false);
                    PrevTip.SetActive(true);
                    NextTip.SetActive(true);
                }
                else if (whichTip == 3)
                {
                    Tip1.SetActive(false);
                    Tip2.SetActive(false);
                    Tip3.SetActive(true);
                    Tip4.SetActive(false);
                    NextTip.SetActive(false);
                }
            }
            else if (PlayerPrefs.GetInt("tips_amt") >= 4)
            {
                NoTips.SetActive(false);
                if (whichTip == 1)
                {
                    Tip1.SetActive(true);
                    Tip2.SetActive(false);
                    Tip3.SetActive(false);
                    Tip4.SetActive(false);
                    PrevTip.SetActive(false);
                }
                else if (whichTip == 2)
                {
                    Tip1.SetActive(false);
                    Tip2.SetActive(true);
                    Tip3.SetActive(false);
                    Tip4.SetActive(false);
                    PrevTip.SetActive(true);
                }
                else if (whichTip == 3)
                {
                    Tip1.SetActive(false);
                    Tip2.SetActive(false);
                    Tip3.SetActive(true);
                    Tip4.SetActive(false);
                    NextTip.SetActive(true);
                }
                else if (whichTip == 4)
                {
                    Tip1.SetActive(false);
                    Tip2.SetActive(false);
                    Tip3.SetActive(false);
                    Tip4.SetActive(true);
                    NextTip.SetActive(false);
                }
            }
            else
            {
                NoTips.SetActive(true);
                Tip1.SetActive(false);
                Tip2.SetActive(false);
                Tip3.SetActive(false);
                Tip4.SetActive(false);
                NextTip.SetActive(false);
                PrevTip.SetActive(false);
            }
        }
    }

    public void nextTip()
    {
        whichTip++;
    }

    public void prevTip()
    {
        whichTip--;
    }
}
