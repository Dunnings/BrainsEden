using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Text level;
    public Button levelLeft;
    public Button levelRight;

    int selectedLevel = 0;

	// Use this for initialization
	void Start () {
        if (Application.levelCount > 1)
        {
            selectedLevel = 1;
            level.text = "1" ;
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
        if (selectedLevel < Application.levelCount-1)
        {
            selectedLevel++;
            level.text = selectedLevel.ToString();
        }
        else
        {
            selectedLevel = 1;
            level.text = selectedLevel.ToString();
        }
    }

    public void clickLeft()
    {
        if (selectedLevel >1)
        {
            selectedLevel--;
            level.text = selectedLevel.ToString();
        }
        else
        {
            selectedLevel = Application.levelCount-1;
            level.text = selectedLevel.ToString();
        }
    }
}
