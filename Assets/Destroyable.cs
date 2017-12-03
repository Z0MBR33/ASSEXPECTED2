using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
        {
        //this.gameObject.SetActive(false);
        if (collision.gameObject.tag == "PunchPoint")
        {
            Debug.Log("Hallo");
            Destroy(this.gameObject);
        }
        
    }
}
