using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public enum GameState
    {
        PREPLAY,
        PLAYING,
        END,
        RESET,
    }

    private GameState gameState;

	// Use this for initialization
	void Start () {
	
	}

    void UpdatePrePlay()
    {

    }
    void UpdatePlaying()
    {

    }

    void UpdateEnd()
    {

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
                break;
            case GameState.END:
                break;
            case GameState.RESET:
                break;
        }
	}
}
