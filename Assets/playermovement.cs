using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rbBody;
    public SpriteRenderer playerSprite;
    public float speed = 1.0f;
    public float JumpSpeed = 5f;
    public Animator animator;
  

    //public BoxCollider2D groundCheck;
    //public LayerMask GroundMask;
    bool isGroundTouch = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.D)) {
            movement.x = 1;
            playerSprite.flipX = false;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
            playerSprite.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("attack");
        }


        if (rbBody.velocity.x != 0 && isGroundTouch) {
            
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
        animator.SetBool("jump", !isGroundTouch);

        if (Input.GetKeyDown(KeyCode.Space) && isGroundTouch)
        {
            
            rbBody.velocity = new Vector2(rbBody.velocity.x, JumpSpeed);
        }



        Debug.Log("IsGround : " + isGroundTouch);

        rbBody.velocity = new Vector2(movement.normalized.x * speed, rbBody.velocity.y);

        //if (Physics2D.OverlapArea(groundCheck.bounds.max, groundCheck.bounds.min, GroundMask)){
        //    isGroundTouch = true;
        //}
        //else {
        //    isGroundTouch=false;
        //}

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) { 
            isGroundTouch = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGroundTouch = false;

        }
    }




}
