using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;


public class StartScreen : MonoBehaviour {

    //public Canvas StartCanvas;

    public Button StartGame;

    public Button QuitGame;
    public Canvas QuitGameCanvas;
    public Button QuitYes;
    public Button QuitNo;


    public Button Credits;
    public Canvas CreditCanvas;
    public Button CreditsReturn;

    public Button HowTo;
    public Canvas HowToCanvas;
    public Button HowToReturn;







    // Use this for initialization
    void Start () {

        //StartCanvas = StartCanvas.GetComponent<Canvas>();

        StartGame = StartGame.GetComponent<Button>();

        QuitGame = QuitGame.GetComponent<Button>();
        QuitGameCanvas = QuitGameCanvas.GetComponent<Canvas>();
        QuitYes = QuitYes.GetComponent<Button>();
        QuitNo = QuitNo.GetComponent<Button>();

        Credits = Credits.GetComponent<Button>();
        CreditCanvas = CreditCanvas.GetComponent<Canvas>();
        CreditsReturn = CreditsReturn.GetComponent<Button>();

        HowTo = HowTo.GetComponent<Button>();
        HowToCanvas = HowToCanvas.GetComponent<Canvas>();
        HowToReturn = HowToReturn.GetComponent<Button>();


        //StartCanvas.enabled = true;

        StartGame.enabled = true;

        QuitGame.enabled = true;
        QuitGameCanvas.enabled = false;
        QuitYes.enabled = false;
        QuitNo.enabled = false;

        Credits.enabled = true;
        CreditCanvas.enabled = false;
        CreditsReturn.enabled = false;

        HowTo.enabled = true;
        HowToCanvas.enabled = false;
        HowToReturn.enabled = false;

    }

    // Update is called once per frame
    void Update () {
		
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
	}


    public void StartGamePressed()
    {
        Debug.Log("start pressed");
        SceneManager.LoadScene(1);
      //Application.LoadLevel(1);
    }



    //QuitGame
    public void QuitGamePressed()
    {
        QuitGameCanvas.enabled = true;
        QuitYes.enabled = true;
        QuitNo.enabled = true;

        StartGame.enabled = false;
        QuitGame.enabled = false;
        Credits.enabled = false; 
        HowTo.enabled = false;
    }

    public void NoPressed()
    {
        QuitGameCanvas.enabled = false;
        QuitYes.enabled = false;
        QuitNo.enabled = false;

        StartGame.enabled = true;
        QuitGame.enabled = true;
        Credits.enabled = true;
        HowTo.enabled = true;
    }

    public void YesPressed()
    {
        Application.Quit();
    }



    //Credits
    public void CreditsPressed()
    {
        CreditCanvas.enabled = true;
        CreditsReturn.enabled = true;

        StartGame.enabled = false;
        QuitGame.enabled = false;
        Credits.enabled = false;
        HowTo.enabled = false;
    }

    public void CreditsReturnPressed()
    {
        CreditCanvas.enabled = false;
        CreditsReturn.enabled = false;

        StartGame.enabled = true;
        QuitGame.enabled = true;
        Credits.enabled = true;
        HowTo.enabled = true;
    }



    //HowTo
    public void HowToPressed()
    {
        HowToCanvas.enabled = true;
        HowToReturn.enabled = true;

        StartGame.enabled = false;
        QuitGame.enabled = false;
        Credits.enabled = false;
        HowTo.enabled = false;
    }

    public void HowToReturnPressed()
    {
        HowToCanvas.enabled = false;
        HowToReturn.enabled = false;

        StartGame.enabled = true;
        QuitGame.enabled = true;
        Credits.enabled = true;
        HowTo.enabled = true;
    }
}
