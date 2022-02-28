using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHitNotes : MonoBehaviour
{
    public float bpm;
    private float speed;

    

    // Update is called once per frame
    void Update()
    {
        speed = bpm / 60;
        transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Target1")
        {
            gameObject.SetActive(false);
            GameManager.instance.Target1.keyPress();
            GameManager.instance.Target1.keyDefault();
            Destroy(this.gameObject);
        }
        else if (other.tag == "Target2")
        {
            gameObject.SetActive(false);
            GameManager.instance.Target2.keyPress();
            GameManager.instance.Target2.keyDefault();
            Destroy(this.gameObject);
        }
        else if (other.tag == "Target3")
        {
            gameObject.SetActive(false);
            GameManager.instance.Target3.keyPress();
            GameManager.instance.Target3.keyDefault();
            Destroy(this.gameObject);
        }
        else if (other.tag == "Target4")
        {
            gameObject.SetActive(false);
            GameManager.instance.Target4.keyPress();
            GameManager.instance.Target4.keyDefault();
            Destroy(this.gameObject);
        }
        else if (other.tag == "Target5")
        {
            gameObject.SetActive(false);
            GameManager.instance.Target5.keyPress();
            GameManager.instance.Target5.keyDefault();
            Destroy(this.gameObject);
        }
    }

    public void setBPM(float val)
    {
        bpm = val;
    }
}
