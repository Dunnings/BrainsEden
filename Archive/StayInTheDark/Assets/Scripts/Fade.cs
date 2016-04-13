using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    public SpriteRenderer spriteRenderer;

    bool fadeOut = true;

    private float minusAlpha = 0.01f;

	// Use this for initialization
	void Start () {
        //spriteRenderer.color = new Color(0.1f, 0.1f, 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
