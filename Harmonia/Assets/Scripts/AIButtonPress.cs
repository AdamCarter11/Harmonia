using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIButtonPress : MonoBehaviour
{   
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

    }

    public void keyPress()
    {
        theSR.sprite = pressedImage;
    }

    public void keyDefault()
    {
        StartCoroutine(resetKey());   
    }

    IEnumerator resetKey()
    {
        yield return new WaitForSeconds(0.1f);
        theSR.sprite = defaultImage;
    }
}