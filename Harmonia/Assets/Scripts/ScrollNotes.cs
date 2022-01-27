using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollNotes : MonoBehaviour
{
    public float bpm;   // scroll speed

    public bool started;
    void Start()
    {
        bpm = bpm / 60f;
    }
    void Update()   //update is called once per frame
    {
        /*
        if (!started)
        {
            if (Input.anyKeyDown)
            {
                started = true;
            }
            else
            {*/
        transform.position -= new Vector3(0f, bpm * Time.deltaTime, 0f);    // transform function moves only on y-axis
        /*                                                                       // (x, y, z) parameters
       }
   }*/
    }
}
