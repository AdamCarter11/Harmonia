using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIButtonPress : MonoBehaviour
{   
    public static AIButtonPress instance;
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

    public IEnumerator keyDefault()
    {
        yield return new WaitForSeconds(1);
        theSR.sprite = defaultImage;
    }
}