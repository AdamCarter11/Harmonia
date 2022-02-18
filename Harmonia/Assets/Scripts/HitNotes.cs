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
    private bool notePlayed = false;

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
                notePlayed = true;
                Debug.Log("noteplayed = true");
                Destroy(this.gameObject);
            }
            else if (canBePressed && great)
            {
                GameManager.instance.NoteHitGreat();
                obtained = true;
                gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
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

       //print(other.tag);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
            great = true;
        }
        if (other.tag == "GreatWindow")
        {
            canBePressed = false;
            if (!obtained)
            {
                GameManager.instance.NoteMiss();
                Destroy(this.gameObject);
            }
        }
    }

    public void setBPM(float val)
    {
        bpm = val;
    }
}
