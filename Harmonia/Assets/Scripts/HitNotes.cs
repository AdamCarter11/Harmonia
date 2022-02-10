using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNotes : MonoBehaviour
{
    private bool obtained = false;
    public bool canBePressed;
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
            if (canBePressed)
            {
                GameManager.instance.NoteHit();
                obtained = true;
                gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
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
