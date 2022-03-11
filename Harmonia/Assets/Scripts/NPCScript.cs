using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color startingColor;
    private GameObject playerObject;
    public AudioSource sfx_s;
    public AudioSource music_s;
    public AudioClip clearThroat;
    public AudioClip mozartBGM;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startingColor = sr.color;
        if (PlayerPrefs.GetInt("Battle Won") != 1)
        {
            music_s.clip = mozartBGM;
            music_s.Play();
        }
            
        //playerObject = GameObject.Find("Player");
        //GetComponent<CircleCollider2D>().radius = playerObject.GetComponent<Player>().checkRadius + 2.5f;
        //print(GetComponent<CircleCollider2D>().radius);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sr.color = Color.green;
            if (PlayerPrefs.GetInt("Battle Won") != 1)
            {
                if (clearThroat != null)
                {
                    sfx_s.Stop();
                    sfx_s.clip = clearThroat;
                    sfx_s.Play();
                }
                music_s.Pause();
            } 
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sr.color = startingColor;
            if (PlayerPrefs.GetInt("Battle Won") != 1)
            {
                music_s.UnPause();
            }
                
        }

    }

}
