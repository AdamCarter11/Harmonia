using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode pressKey;

    // public AudioSource keySound;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pressKey))
        {
            // if(keySound != null){
            //     keySound.Play();
            // } else {
            //     Debug.Log("ButtonPress: error : no sound object found");
            // }
            theSR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(pressKey))
        {
            theSR.sprite = defaultImage;
        }
    }
}
