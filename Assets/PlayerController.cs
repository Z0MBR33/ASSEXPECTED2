using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public string playernumber;

    public float speed;
    public float jumpForce;
    public Rigidbody2D myRb;
    public int playerColor;

    private float currentX;
    private bool grounded;
    private bool inJump;
    private SpriteRenderer myRenderer;

	// Use this for initialization
	void Start () {
        myRb = GetComponent<Rigidbody2D>();
        myRenderer = GetComponentInChildren<SpriteRenderer>();
        //myRenderer.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
        grounded = checkGround();
        checkAnimationState();
        currentX  = Input.GetAxis("Horizontal_" + playernumber);
        Vector3 moveX = new Vector3(currentX * speed * Time.deltaTime, 0, 0);
        transform.position += moveX;
        
        if (Input.GetButtonDown("Jump_" + playernumber) && grounded)//!inJump)
        {
            myRb.AddForce(new Vector2(0, jumpForce));
        }

	}

    private void checkAnimationState()
    {
        if (grounded)
        {
            //Grounded State in anim;
            myRenderer.color = Color.white;
        }
        else if(myRb.velocity.y > 0)
        {
            //jump
            myRenderer.color = Color.red;
        }
        else
        {
            //fall
            myRenderer.color = Color.green;
        }
    }

    bool checkGround()
    {
        Debug.Log(transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0,-0.01f,0), -Vector2.up,0.15f);
        
        if (hit.collider != null)
        {
            //Debug.Log("True ..." + Vector2.Distance(hit.point, transform.position));
            //Destroy(hit.collider.gameObject);
            return true;
           
        }
        else
        {
            Debug.Log("False");
            return false;
        }
        
    }
}
