using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.P))
        {
            switch (Level.level.gameState)
            {
                case Level.GameState.PAUSED:
                    Level.level.gameState = Level.GameState.PLAYING;
                    this.GetComponent<Canvas>().enabled = false;
                    break;
                case Level.GameState.PLAYING:
                    Level.level.gameState = Level.GameState.PAUSED;
                    this.GetComponent<Canvas>().enabled = true;
                    break;
            }
        }   
	}

    public void exitPause()
    {
        Level.level.gameState = Level.GameState.PLAYING;
    }
}
