using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class AudioToggle : MonoBehaviour {


    public Image audioIcon;
    public Sprite audioOn;
    public Sprite audioOff;

    public bool aud = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void toggle()
    {
        aud = !aud;
        if (aud)
        {
            audioIcon.sprite = audioOn;
            PlayerPrefs.SetInt("volume", 1);
        }
        else
        {
            audioIcon.sprite = audioOff;
            PlayerPrefs.SetInt("volume", 0);
        }
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetVolume(PlayerPrefs.GetInt("volume"));
        }
    }
}
