using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReached : MonoBehaviour {
    public bool player1ReachedCurrent;
    public bool player2ReachedCurrent;
    public bool nextLevel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        if(player1ReachedCurrent && player2ReachedCurrent)
        {
            //switchLevel;
            Debug.Log("NextLevel");
            nextLevel = true;
        }
        else
        {
            player1ReachedCurrent = false;
            player2ReachedCurrent = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "player1")
        {
            player1ReachedCurrent = true;

        }
        if (collision.gameObject.tag == "player2")
        {
            player2ReachedCurrent = true;

        }

    }

    internal void setPlayerReached(string playernumber)
    {
        Debug.Log("ChoosePlayer");
        if(playernumber == "1")
        {
            player1ReachedCurrent = true;
        }
        if (playernumber == "2")
        {
            player2ReachedCurrent = true;
        }
    }
}
