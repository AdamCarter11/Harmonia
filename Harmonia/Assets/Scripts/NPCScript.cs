using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color startingColor;
    private GameObject playerObject;
    public AudioSource clearThroat;
    public AudioSource mozartBGM;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startingColor = sr.color;
        mozartBGM.Play();
        //playerObject = GameObject.Find("Player");
        //GetComponent<CircleCollider2D>().radius = playerObject.GetComponent<Player>().checkRadius + 2.5f;
        //print(GetComponent<CircleCollider2D>().radius);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            sr.color = Color.green;
            if(clearThroat != null){
                clearThroat.Play();
            }
            mozartBGM.Pause();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            sr.color = startingColor;
            mozartBGM.UnPause();
        }
       
    }
    
}
