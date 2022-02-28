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
        if (other.tag == "Activator")
        {
            GameManager.instance.AINoteHitPerfect();
            gameObject.SetActive(false);
            Destroy(this.gameObject);
            AIButtonPress.instance.keyPress();
            StartCoroutine(AIButtonPress.instance.keyDefault());
        }
    }

    public void setBPM(float val)
    {
        bpm = val;
    }
}
