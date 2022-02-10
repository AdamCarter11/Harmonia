using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    /*
    [SerializeField]
    private Vector3 interactLength;
    [SerializeField]
    private float rayCastLength;
    */
    [SerializeField]
    private LayerMask npcLayer;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private GameObject whichToInteractWith;

    public Inventory inventory;
    public SettingsManager settings;
    
    public AudioSource walking;
    public AudioSource startBattle;

    public float checkRadius;

    bool Started = false;
    bool Ended = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInputs();
        walkingSound();
        CheckCollision();
        //
        if(whichToInteractWith != null && Input.GetKeyDown(KeyCode.E)){
            print("Interacted with: " + whichToInteractWith.name);
            //where we want to put the interact logic (open scene, open UI, whatever)
            startBattle.Play();
            Started = true;  //sfx started when pressing E
        }
        //it is not playing and started -> sfx ended
        if(startBattle.isPlaying == false && Started == true){
            Ended = true;
        }
        //if both, then load the scene
        if(Started == true && Ended == true){
           SceneManager.LoadScene("TalkingScene1");
           Debug.Log("talking scene");
        }
        
    }

    private void FixedUpdate() {
        if (!inventory.getActive() && !settings.settingsActive())
        {
            rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void loadScene(string scene){
        SceneManager.LoadScene(scene);
    }

    void GetInputs(){
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");
        //print("x movement: " + xMovement + "y Movement: " + yMovement);
        moveDir = new Vector2(xMovement, yMovement);
        
        /*
        if(moveDir.x != 0 || moveDir.y != 0){
            facingDir = moveDir;
        }
        */
    }

    void CheckCollision(){
        //theres almost definitly a better way of doing this
        /*
        if(Physics2D.Raycast(transform.position + interactLength, facingDir, rayCastLength, npcLayer)){
            whichToInteractWith = Physics2D.Raycast(transform.position + interactLength, facingDir, rayCastLength, npcLayer).transform.gameObject;
        }
        if(Physics2D.Raycast(transform.position - interactLength, facingDir, rayCastLength, npcLayer)){
            whichToInteractWith = Physics2D.Raycast(transform.position - interactLength, facingDir, rayCastLength, npcLayer).transform.gameObject;
        }
        
        if(Physics2D.OverlapCircle(transform.position, checkRadius, npcLayer)){
            whichToInteractWith = Physics2D.OverlapCircle(transform.position, checkRadius, npcLayer).transform.gameObject;
        }
        */
    }

    /*
    private void OnDrawGizmos(){
        Gizmos.color = Color.green;
        //Vector3 gizmoDir = new Vector3(facingDir.x, facingDir.y, 0);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * checkRadius);
        //Gizmos.DrawLine(transform.position - interactLength, transform.position - interactLength + gizmoDir * rayCastLength); 
    }
    */

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("NPC")){
            //other.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            whichToInteractWith = other.gameObject;
            Variables.NPCName = whichToInteractWith.name;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("NPC")){
            //other.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            whichToInteractWith = null;
            Variables.NPCName = null;
        }
    }

    private void walkingSound(){
        if(rb.velocity.magnitude > 0){
            if(walking.isPlaying){
                //do nothing here
            } else {
                walking.Play();
            }
        } else {
            walking.Stop();
        }
    }

}
