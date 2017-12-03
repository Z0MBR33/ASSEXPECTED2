using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Jump_1") || Input.GetButtonDown("Jump_2"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("StartScreen");
        }
    }
}
