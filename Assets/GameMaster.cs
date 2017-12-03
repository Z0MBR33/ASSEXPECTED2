using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {
    public Color col1;
    public Color col2;
    public GameObject fat;
    public GameObject slim;
    public Transform StartPoint_pl1;
    public Transform StartPoint_pl2;

    public DoorReached myDoor;

    public String sceneName;
    //public GameObject SoundWave;

    private GameObject pl1;
    private GameObject pl2;

    public Canvas CanvasExit;
    public Canvas CanvasLost;
    public Canvas CanvasWon;

    // Use this for initialization
    void Start () {
        setColorPattern();
        setRandomPlayer();

        //pl1.GetComponent<PlayerController>().playerColor = col1;
        //pl2.GetComponent<PlayerController>().playerColor = col2;

        //pl1.GetComponent<PlayerController>().SoundWave = SoundWave;
        //pl2.GetComponent<PlayerController>().SoundWave = SoundWave;

        pl1.transform.position = StartPoint_pl1.position;
        pl2.transform.position = StartPoint_pl2.position;

        Instantiate(pl1);
        Instantiate(pl2);

        //CanvasExit = CanvasExit.GetComponent<Canvas>();
        CanvasExit.enabled = false;
        //CanvasLost = CanvasLost.GetComponent<Canvas>();
        CanvasLost.enabled = false;
        //CanvasWon = CanvasWon.GetComponent<Canvas>();
        CanvasWon.enabled = false;
    }

    private void initiate()
    {
        throw new NotImplementedException();
    }

    private void setRandomPlayer()
    {
        float myFloat = UnityEngine.Random.Range(0, 1);
        if (myFloat > 0.5f)
        {
            pl1 = fat;
            pl2 = slim;
        }

        else{
            pl1 = slim;
            pl2 = fat;
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CanvasExit != null)
            {
                CanvasExit.enabled = true;
                Time.timeScale = 0;
            }
            //Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            CanvasLost.enabled = true;
            Time.timeScale = 0;
            //Application.Quit();
        }   
        
        
        if (myDoor.nextLevel)
        {
            if (sceneName == "Won")
            {
                CanvasWon.enabled = true;
                Time.timeScale = 0;
                //Application.Quit();

            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
            
        }
    }

    void setColorPattern()
    {
        float myFloat = UnityEngine.Random.Range(0, 1);
        if (myFloat > 0.5f)
        {
            col1 = Color.green;
            col2 = Color.red;
        }
        else{
            col1 = Color.yellow;
            col2 = Color.cyan;
        }
    }
}
