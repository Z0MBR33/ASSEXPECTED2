using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {
    //AudioSource mySource;
    //AudioClip destroyClip;
	// Use this for initialization
	void Start () {
        //mySource.clip = destroyClip;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
        {
        //this.gameObject.SetActive(false);
        if (collision.gameObject.tag == "PunchPoint")
        {
            //mySource.Play();
            Destroy(this.gameObject);
        }
        
    }
}
