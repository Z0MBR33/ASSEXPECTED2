using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public string playernumber;
    public bool CanMoveAgain = true;

    public float speed;
    public float jumpForce;
    public Rigidbody2D myRb;
    public Color playerColor;

    public GameObject HitPointRight;
    public GameObject HitPointLeft;


    private float currentDirection = 1;
    private float currentX;
    private bool grounded;
    private bool Jump;
    private bool sound;
    public SpriteRenderer myRenderer;
    public SpriteRenderer myArmRenderer;
    public SpriteRenderer myEyeRenderer;
    public GameObject SoundWave;
    public Animation SyncArmPush;

    public Animator myAnim;
    public Animator myArmAnim;
    public Animator myEyeAnim;

    public int Counter;
    // Use this for initialization
    void Start () {
        myRb = GetComponent<Rigidbody2D>();
        
        myRenderer.color = playerColor;
        myArmRenderer.color = playerColor;
        
        SoundWave.GetComponent<SpriteRenderer>().color = playerColor;

    }
	
	// Update is called once per frame
	void Update () {

        grounded = checkGround();
        checkAnimationState();
        checkInput();
        
        Vector3 moveX = new Vector3(currentX * speed * Time.deltaTime, 0, 0);
        if (WallGroundCheck(moveX))
        {
            transform.position += moveX;            

        }
        else
        {
            
          
        }
        
        
        if (Jump && grounded)//!inJump)
        {
            myRb.AddForce(new Vector2(0, jumpForce));
            myAnim.SetTrigger("Jump");
            myArmAnim.SetTrigger("Jump");
            myEyeAnim.SetTrigger("Jump");
            Jump = false;
        }

        if (sound)
        {
            SoundWave.SetActive(true);
            if(Counter == 0)
            {
                SoundWave.transform.position -= new Vector3(0, 0.01f, 0);
                Counter = 1;
            }
            else
            {
                SoundWave.transform.position += new Vector3(0, 0.01f, 0);
                Counter = 0;
            }
            
        }
        else
        {
            SoundWave.SetActive(false);
            if(Counter == 1)
            {
                SoundWave.transform.position += new Vector3(0, 0.01f, 0);
                Counter = 2;
            }
            else if(Counter == 0)
            {
                SoundWave.transform.position -= new Vector3(0, 0.01f, 0);
                Counter = 2;
            }
            
        }

	}

    private void checkInput()
    {
        
        if (CanMoveAgain)
        {

            currentX = Input.GetAxis("Horizontal_" + playernumber);
            if (currentX < 0)
            {
                currentDirection = -1;
                myRenderer.flipX = true;
                myArmRenderer.flipX = true;
                myEyeRenderer.flipX = true;
            }
            else if (currentX > 0)
            {
                currentDirection = 1;
                myRenderer.flipX = false;
                myArmRenderer.flipX = false;
                myEyeRenderer.flipX = false;
            }
            
            if (grounded && currentX < 0.01 && currentX > -0.01 && Input.GetButtonDown("Action_" + playernumber))
            {
                doActionMove();
                CanMoveAgain = false;
            }

            Jump = Input.GetButtonDown("Jump_" + playernumber);
            sound = Input.GetButton("Sound_" + playernumber);


        }

        
    }

    private bool WallGroundCheck(Vector3 move)
    {
        int layerMask = ~(LayerMask.GetMask("SoundWave"));

        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(currentDirection * (0.51f), -transform.localScale.y/2, 0), new Vector2(currentDirection,0), move.magnitude, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(currentDirection * (0.51f), transform.localScale.y/2, 0), new Vector2(currentDirection, 0), move.magnitude, layerMask);
        if (hit1.collider != null && hit2.collider != null)
        {
            myArmAnim.SetBool("ArmPush", true);
            
            myAnim.SetBool("ArmPush", false);
            myEyeAnim.SetBool("Push", false);
            if (hit1.collider.tag == "MoveAble" || hit2.collider.tag == "MoveAble")
            {
                
                return true;
            }
            //Debug.Log("True ..." + Vector2.Distance(hit.point, transform.position));
            //Destroy(hit2.collider.gameObject);
            return false;

        }
        else
        {

            //Debug.Log("False");
            myArmAnim.SetBool("ArmPush", false);
            
            myAnim.SetBool("ArmPush", true);
            myEyeAnim.SetBool("Push", true);
            return true;
        }
    }

    private void checkAnimationState()
    {
        if (checkGround())
        {
            if(currentX != 0)
            {
                myAnim.SetBool("Grounded", true);
                myAnim.SetBool("Fall", false);
                myArmAnim.SetBool("Grounded", true);
                myArmAnim.SetBool("Fall", false);
                myEyeAnim.SetBool("Grounded", true);
                myEyeAnim.SetBool("Fall", false);
                myAnim.SetBool("Run", true);
                myArmAnim.SetBool("Run", true);
                myEyeAnim.SetBool("Run", true);
                
            }
            else
            {
                myAnim.SetBool("Grounded", true);
                myAnim.SetBool("Fall", false);
                myArmAnim.SetBool("Grounded", true);
                myArmAnim.SetBool("Fall", false);
                myEyeAnim.SetBool("Grounded", true);
                myEyeAnim.SetBool("Fall", false);
                myArmAnim.SetBool("Run", false);
                myAnim.SetBool("Run", false);
                myEyeAnim.SetBool("Run", false);
                //Debug.Log("Ground");
            }
            //Grounded State in anim;
            //myRenderer.color = Color.white;
        }
        else
        {
            //myAnim.SetTrigger("Jump");
            myAnim.SetBool("Grounded", false);
            myEyeAnim.SetBool("Grounded", false);
            myArmAnim.SetBool("Grounded", false);
            myAnim.SetBool("Fall", true);
            //jump
            //myRenderer.color = Color.red;
        }

    }

    bool checkGround()
    {
        //Debug.Log(transform.position);
        int layerMask = ~(LayerMask.GetMask("SoundWave"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0,-0.01f,0), -Vector2.up,0.015f,layerMask);
        
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "player1" || hit.collider.gameObject.tag == "player2")
            {
                transform.parent = hit.collider.gameObject.transform; 
            }
            else
            {
                transform.parent = null;
            }
            //Debug.Log("True ..." + Vector2.Distance(hit.point, transform.position));
            //Destroy(hit.collider.gameObject);
            return true;
           
        }
        else
        {
            transform.parent = null;
            //Debug.Log("False");
            return false;
        }
        
    }

    void doActionMove()
    {
        if(playernumber == "2")
        {
            Hit();
        }
        if (playernumber == "1")
        {
            Kick();
        }
    }

    void Kick()
    {
        myArmAnim.SetTrigger("Action");
        myArmAnim.SetBool("CanMoveAgain", false);

        myAnim.SetTrigger("Action");
        myAnim.SetBool("CanMoveAgain", false);

        myEyeAnim.SetTrigger("Action");
        myEyeAnim.SetBool("CanMoveAgain", false);

        

        HitPointRight.SetActive(true);
        if (currentDirection < 0)
        {
            HitPointRight.SetActive(true);
        }
        HitPointRight.transform.position += new Vector3(0, 0.1f, 0);
        if (currentDirection < 0)
        {
            HitPointLeft.SetActive(true);
        }
        HitPointLeft.transform.position += new Vector3(0, 0.1f, 0);
    }

    void Hit()
    {
        myAnim.SetTrigger("Action");
        myAnim.SetBool("CanMoveAgain", false);

        myEyeAnim.SetTrigger("Action");
        myEyeAnim.SetBool("CanMoveAgain",false);

        myArmAnim.SetTrigger("Action");
        myArmAnim.SetBool("CanMoveAgain", false);

        HitPointRight.SetActive(true);
        if (currentDirection < 0)
        {
            HitPointRight.SetActive(true);
        }
        HitPointRight.transform.position += new Vector3(0, 0.1f, 0);
        if(currentDirection < 0)
        {
            HitPointLeft.SetActive(true);
        }
        HitPointLeft.transform.position += new Vector3(0, 0.1f, 0);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KickBox")
        {
            Kick kick = collision.gameObject.GetComponent<Kick>();

            if (kick != null)
            {
                myRb.AddForce(new Vector2(kick.Direction * 700, 500));
                collision.gameObject.SetActive(false);
            }
        }

    }
}
