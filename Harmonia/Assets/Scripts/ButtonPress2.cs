using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress2 : MonoBehaviour
{
    public KeyCode pressKey;
    private bool canBePressed;
    // public AudioSource keySound;

    void Start()
    {
        canBePressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pressKey))
        {
            if (!canBePressed)
            {
                GameManager.instance.NoteMiss();
            }
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
