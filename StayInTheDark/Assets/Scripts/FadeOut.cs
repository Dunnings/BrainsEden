using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    public SpriteRenderer im;
    private float op = 1.0f;

	// Use this for initialization
	void Start () {
        im.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    Texture2D fadeTexture;
     float fadeSpeed = 0.2f;
     int drawDepth = -1000;
 
     private float alpha = 1.0f; 
     private float fadeDir = -1;
 
     void OnGUI(){
     
         alpha += fadeDir * fadeSpeed * Time.deltaTime;  
         alpha = Mathf.Clamp01(alpha);   
     
         im.color = new Color(0f,0f,0f, alpha);
     }
}
