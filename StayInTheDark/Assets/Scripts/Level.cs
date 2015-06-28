using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public static Level level;

    public Level nextLvl;

    void Start()
    {
        level = this;
        colourManager.m_colourManager.generateColour();
    }

    public enum GameState
    {
        PREPLAY,
        PLAYING,
        FAIL,
        WIN,
        LOADLEVEL,
        RESET,
    }

    public GameState gameState = GameState.PLAYING;

    void UpdatePrePlay()
    {

    }
    void UpdatePlaying()
    {

    }

    void NextLevel()
    {
        
    }

    void FAIL()
    {
        colourManager.m_colourManager.genColours();
        Debug.Log("Ending");
        Player.Instance.RESET();
        AudioManager.Instance.RESET();
        gameState = GameState.PLAYING;
    }

    void WIN()
    {
        if (Application.levelCount-1 > Application.loadedLevel)
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
        else
        {
            Application.LoadLevel(0);
        }
    }

    void LoadLevel()
    {
        Debug.Log("End Level");
    }

    void Reset()
    {

    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
	
	// Update is called once per frame
	void Update () {
	    switch(gameState)
        {
            case GameState.PREPLAY:
                break;
            case GameState.PLAYING:
                UpdatePlaying();
                break;
            case GameState.FAIL:
                FAIL();
                break;
            case GameState.WIN:
                WIN();
                break;
            case GameState.RESET:
                break;
            case GameState.LOADLEVEL:
                LoadLevel();
                break;
        }
	}
}
