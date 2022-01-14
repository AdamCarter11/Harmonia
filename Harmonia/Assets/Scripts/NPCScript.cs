using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color startingColor;
    private GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startingColor = sr.color;
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
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            sr.color = startingColor;
        }
    }
    
}
