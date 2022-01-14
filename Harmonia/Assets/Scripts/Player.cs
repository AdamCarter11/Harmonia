using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Vector3 interactLength;
    [SerializeField]
    private float rayCastLength;
    [SerializeField]
    private LayerMask npcLayer;

    private Rigidbody2D rb;   
    private Vector2 moveDir;
    private GameObject whichToInteractWith;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInputs();
        CheckCollision();
        if(whichToInteractWith != null && Input.GetKeyDown(KeyCode.E)){
            print("Interacted with: " + whichToInteractWith.name);
            //where we want to put the interact logic (open scene, open UI, whatever)
            SceneManager.LoadScene("TalkingScene1");
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

    void GetInputs(){
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");
        //print("x movement: " + xMovement + "y Movement: " + yMovement);
        moveDir = new Vector2(xMovement, yMovement);
    }

    void CheckCollision(){
        if(Physics2D.Raycast(transform.position + interactLength, moveDir, rayCastLength, npcLayer)){
            whichToInteractWith = Physics2D.Raycast(transform.position + interactLength, moveDir, rayCastLength, npcLayer).transform.gameObject;
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position + interactLength, transform.position + interactLength + Vector3.right * rayCastLength);
    }
}
