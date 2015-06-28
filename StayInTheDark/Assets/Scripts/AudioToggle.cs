using UnityEngine;
using System.Collections;

public class AudioToggle : MonoBehaviour {

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
        if (aud)
        {
            //AudioManager.Instance.mute(){

        }
    }
}
