using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microphone1 : MonoBehaviour {
    public GameObject linkedObject;
    public bool singASong;
    public int listeningPlayerNumber;

    public bool currentUpdate;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        
        if (!currentUpdate)
        {
            singASong = false;
        }
        currentUpdate = false;
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
            //this.gameObject.SetActive(false);
            Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "SoundWave")
        {
            if(collision.gameObject.transform.parent.tag == "player" + listeningPlayerNumber)
            {
                Debug.Log("Hi");
                singASong = true;
                currentUpdate = true;
            }
            
        }

    }

    private void doSomething()
    {
        //throw new NotImplementedException();
    }
}
