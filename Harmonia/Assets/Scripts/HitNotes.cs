using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNotes : MonoBehaviour
{
    private bool obtained = false;
    public bool canBePressed;
    public bool perfect;
    public bool great;
    public KeyCode pressKey;
    public float bpm;
    private float speed;

    // Update is called once per frame
    void Update()
    {
        speed = bpm / 60;
        transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
        if (Input.GetKeyDown(pressKey))
        {
            if (canBePressed && perfect)
            {
                GameManager.instance.NoteHitPerfect();
                obtained = true;
                gameObject.SetActive(false);
            }
            else if (canBePressed && great)
            {
                GameManager.instance.NoteHitGreat();
                obtained = true;
                gameObject.SetActive(false);
            }
        }
        if (transform.position.y <= -6)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GreatWindow")
        {
            canBePressed = true;
            great = true;
        }
        else if (other.tag == "Activator")
        {
            canBePressed = true;
            perfect = true;
        }
        else if (other.tag == "GreatWindow2")
        {
            canBePressed = true;
            great = true;
        }
        
        print(other.tag);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "GreatWindow2")
        {
            canBePressed = false;
            if (!obtained)
                GameManager.instance.NoteMiss();
        }
    }

    public void setBPM(float val)
    {
        bpm = val;
    }
}
