using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAfterSecnds : MonoBehaviour {
    public float time = 2;
	// Use this for initialization
	void Start () {
        StartCoroutine(WaitForMe());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump_1") || Input.GetButtonDown("Jump_2") || Input.GetButtonDown("Start_1") || Input.GetButtonDown("Start_2"))
        {
            SceneManager.LoadScene("StartScreen");
        }
	}

    IEnumerator WaitForMe()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("StartScreen");
    }
}
