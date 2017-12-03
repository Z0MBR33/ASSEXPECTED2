using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour {
    public Animator myAnim;
    public Microphone1 linkedMic;
	// Use this for initialization
	void Start () {
        myAnim.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (linkedMic.singASong)
        {
            myAnim.SetBool("Play",true);
        }
        else
        {
            myAnim.SetBool("Play", false);
        }
	}
}
