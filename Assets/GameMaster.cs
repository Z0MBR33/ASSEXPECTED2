using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public Color col1;
    public Color col2;
    public GameObject fat;
    public GameObject slim;
    public Transform StartPoint_pl1;
    public Transform StartPoint_pl2;
    public GameObject SoundWave;

    private GameObject pl1;
    private GameObject pl2;
    
    // Use this for initialization
    void Start () {
        setColorPattern();
        setRandomPlayer();

        pl1.GetComponent<PlayerController>().playerColor = col1;
        pl2.GetComponent<PlayerController>().playerColor = col2;

        //pl1.GetComponent<PlayerController>().SoundWave = SoundWave;
        //pl2.GetComponent<PlayerController>().SoundWave = SoundWave;

        pl1.transform.position = StartPoint_pl1.position;
        pl2.transform.position = StartPoint_pl2.position;

        Instantiate(pl1);
        Instantiate(pl2);
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
