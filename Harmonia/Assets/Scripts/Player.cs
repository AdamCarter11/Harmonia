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
    private SpriteRenderer sr;
    private Vector2 moveDir;
    private GameObject whichToInteractWith;
    private Animator anim;
    private string direction;

    public Inventory inventory;
    //public SettingsManager settings;

    public AudioSource audio_s;
    public AudioClip walking;
    public AudioClip startBattle;
    public AudioClip clockFlappingNoise;

    public Sprite walk_forward;
    public Sprite walk_backward;
    public Sprite walk_right;
    public Sprite walk_left;

    public GameObject Tutorial_tips;
    public GameObject Tips1;
    public GameObject Tips2;
    public bool tutorial;

    public float checkRadius;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        if(PlayerPrefs.GetFloat("playerX") != 0 && PlayerPrefs.GetFloat("playerX") != 0){
            transform.position = new Vector3(PlayerPrefs.GetFloat("playerX"), PlayerPrefs.GetFloat("playerY"), transform.position.z);
            print("save worked");
        }
        else{
            print("save failed");
        }
        if (PlayerPrefs.GetInt("tips_amt") == 0)
        {
            Tutorial_tips.SetActive(true);
            Tips1.SetActive(true);
            tutorial = true;
        }
        else
        {
            tutorial = false;
        }
    }

    void Update()
    {
        GetInputs();
        walkingSound();
        CheckCollision();
        if (whichToInteractWith != null && Input.GetKeyDown(KeyCode.E))
        {
            print("Interacted with: " + whichToInteractWith.name);
            //where we want to put the interact logic (open scene, open UI, whatever)
            audio_s.clip = startBattle;
            audio_s.Play();
            persistantManager.Instance.setDialogue("first encounter");
            SceneManager.LoadScene("TalkingScene1");
        }
    }

    private void FixedUpdate()
    {
        if (!inventory.getActive() && !tutorial) // && !settings.settingsActive()
        {
            rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (moveDir.y > 0)
        {
            anim.Play("Player_WalkBack");
            direction = "Back";
        }
        else if (moveDir.y < 0)
        {
            anim.Play("Player_WalkForward");
            direction = "Forward";
        }
        else if (moveDir.y == 0 && moveDir.x > 0)
        {
            anim.Play("Player_WalkRight");
            direction = "Right";
        }
        else if (moveDir.y == 0 && moveDir.x < 0)
        {
            anim.Play("Player_WalkLeft");
            direction = "Left";
        }
        else
        {
            if (direction == "Forward")
            {
                anim.Play("Player_IdleBack");
            }
            else if (direction == "Back")
            {
                anim.Play("Player_IdleForward");
            }
            else if (direction == "Right")
            {
                anim.Play("Player_IdleRight");
            }
            else if (direction == "Left")
            {
                anim.Play("Player_IdleLeft");
            }
        }
    }

    private void OnDestroy() {
        //checks when scene changes, used to save players position
        PlayerPrefs.SetFloat("playerX", transform.position.x);
        PlayerPrefs.SetFloat("playerY", transform.position.y);
        print(PlayerPrefs.GetFloat("playerY"));
    }

    void GetInputs()
    {
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

    void CheckCollision()
    {
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            //other.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            whichToInteractWith = other.gameObject;
            Variables.NPCName = whichToInteractWith.name;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            //other.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            whichToInteractWith = null;
            Variables.NPCName = null;
        }
    }

    private void walkingSound()
    {
        if (rb.velocity.magnitude > 0)
        {
            if (audio_s.isPlaying)
            {
                //do nothing here
            }
            else
            {
                audio_s.clip = walking;
                audio_s.Play();
            }
        }
        else if (audio_s.isPlaying && audio_s.clip == walking)
        {
            audio_s.Stop();
        }
    }

    public void nextTip()
    {
        if (PlayerPrefs.GetInt("tips_amt") == 0)
        {
            PlayerPrefs.SetInt("tips_amt", 1);
            Tips1.SetActive(false);
            Tips2.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("tips_amt") == 1)
        {
            PlayerPrefs.SetInt("tips_amt", 2);
            Tips2.SetActive(false);
            Tutorial_tips.SetActive(false);
            tutorial = false;
        }
    }
}
