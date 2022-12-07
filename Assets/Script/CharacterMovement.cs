using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public BoxCollider2D charCollider;

    Vector2 movement;
    Vector2 mousePos;

    void Start(){
        Time.timeScale = 1f;
        charCollider = charCollider.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement != Vector2.zero){
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetKeyDown("a") || Input.GetKeyDown("d")){
            charCollider.size = new Vector3 (0.6298016f, 0.4884229f);
        }
        else if(Input.GetKeyDown("w") || Input.GetKeyDown("s")){
            charCollider.size = new Vector3 (0.7463535f, 0.4884229f);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            moveSpeed *= 1.5f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            moveSpeed /= 1.5f;
        }
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime); 
    }
}
