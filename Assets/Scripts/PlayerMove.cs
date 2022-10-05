using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    const float doubleClickTime = 0.2f;
    float lastClickTime;
    public Animator anim;
    bool facingRight = true;
    public Rigidbody2D myRigidBody;
    public float jumpHigh;
    public LayerMask ground;
    public Transform groundCheck;
    //class
    public GameOverScript gameOver;



    [Header("Slide Wall")]
    public float wallSlideSpeed = 0.2f;
    public float wallDistance = 0.5f;
    public Transform WallCheckHit;
    public float wallJumpTime = 0.2f;






    void Update()
    {
        anim.SetTrigger("Release");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (facingRight)
            {
                myRigidBody.velocity = new Vector2(3f, jumpHigh);
            }
            else
            {
                myRigidBody.velocity = new Vector2(-3f, jumpHigh);
            }
            

            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick < doubleClickTime)
            {
                
                anim.SetTrigger("Double");
            }
            else
            {
                anim.SetTrigger("Space");
            }
            lastClickTime = Time.time;


        }


        // flip if collide with the ground
        if (IsGrounded())
        {
            
            if (facingRight)
            {
                Flip();
                
            }
            else if (!facingRight)
            {
                Flip();

            }
            
        }


        //wall slide
        if (IsWall())
        {
            anim.SetTrigger("Slide");
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Mathf.Clamp(myRigidBody.velocity.y, wallSlideSpeed, float.MaxValue));
        }

        
        

    }









    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    // check if in the ground
    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.transform.position, Vector2.left, .1f, ground);
        return hit;
    }
    bool IsWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(WallCheckHit.transform.position, Vector2.left, .1f, ground);
        return hit;
    }
    public void GameOver()
    {
        //gameOver animation!
        anim.SetTrigger("Die");
        //score
        gameOver.SetUp(ScoreText.distance.ToString("F1"));
        //stop Player from falling!
        myRigidBody.simulated = false;
        //make the Player vanished
        //gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //stop the Player movement!
        GetComponent<PlayerMove>().enabled = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Push"))
        {
            collision.gameObject.GetComponent<FocedPush>().ForcedToJump();
        }
    }
}