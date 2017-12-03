using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public Microphone1 linkedMic;
    public Transform StartPoint;
    public Transform EndPoint;

    public float speed;

    private Transform currentTarget;

	// Use this for initialization
	void Start () {
        currentTarget = EndPoint;
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position == currentTarget.position)
        {
            SwitchTarget();
        }
        if (linkedMic.singASong)
        {
            movePlatfrom();
        }
        else
        {
            
        }
    }

    private void SwitchTarget()
    {
        if(currentTarget == StartPoint)
        {
            currentTarget = EndPoint;
        }
        else
        {
            currentTarget = StartPoint;
        }
    }

    private void movePlatfrom()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed);
    }
}
