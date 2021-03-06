﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Text level;
    public Button levelLeft;
    public Button levelRight;

    public Sprite audOff;
    public Sprite audOn;

    public Image audioIcon;

    public AudioClip leftrightClickSound;

    public AudioSource audSource;
    public AudioSource audSource2;

    int selectedLevel = 0;

    public GameObject creditsPanel;

	// Use this for initialization
	void Start () {
        if (Application.levelCount > 1)
        {
            selectedLevel = 1;
            level.text = "Level: 1" ;
        }
        toggleAudio();
        
	}

    public void toggleAudio()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            if (PlayerPrefs.GetInt("volume") == 0)
            {
                audioIcon.sprite = audOff;
                audSource.volume = 0f;
                audSource2.volume = 0f;
            }
            else
            {
                audioIcon.sprite = audOn;
                audSource.volume = 1f;
                audSource2.volume = 1f;
            }

        }
        else
        {
            audioIcon.sprite = audOn;
            audSource.volume = 1f;
            audSource2.volume = 1f;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            clickRight();
        } 
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            clickLeft();
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            clickPlay();
        }
	}

    public void clickPlay()
    {
        Application.LoadLevel(selectedLevel);
    }

    public void clickExit()
    {
        Application.Quit();
    }

    public void clickRight()
    {
        audSource2.PlayOneShot(leftrightClickSound);
        if (selectedLevel < Application.levelCount-1)
        {
            selectedLevel++;
            level.text = "Level: " + selectedLevel.ToString();
        }
        else
        {
            selectedLevel = 1;
            level.text = "Level: " + selectedLevel.ToString();
        }
    }

    public void clickLeft()
    {
        audSource2.PlayOneShot(leftrightClickSound);
        if (selectedLevel >1)
        {
            selectedLevel--;
            level.text = "Level: " + selectedLevel.ToString();
        }
        else
        {
            selectedLevel = Application.levelCount-1;
            level.text = "Level: " + selectedLevel.ToString();
        }
    }

    public void clickCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void creditsBack()
    {
        creditsPanel.SetActive(false);
    }
}
