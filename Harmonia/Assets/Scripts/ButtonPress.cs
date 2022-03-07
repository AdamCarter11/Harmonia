using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode pressKey;
    private bool canBePressed;
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
            if (!canBePressed)
            {
                GameManager.instance.NoteMiss();
            }
        }

        if (Input.GetKeyUp(pressKey))
        {
            theSR.sprite = defaultImage;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canBePressed = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canBePressed = false;
    }
}
