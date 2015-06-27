using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public static Level level;

    void Start()
    {
        level = this;
    }

    public enum GameState
    {
        PREPLAY,
        PLAYING,
        END,
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

    void UpdateEnd()
    {
        Debug.Log("Ending");
        Player.Instance.RESET();
        DamageAudioManager.Instance.RESET();
        gameState = GameState.PLAYING;
    }

    void LoadLevel()
    {
        Debug.Log("End Level");
    }

    void Reset()
    {

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
            case GameState.END:
                UpdateEnd();
                break;
            case GameState.RESET:
                break;
            case GameState.LOADLEVEL:
                LoadLevel();
                break;
        }
	}
}
