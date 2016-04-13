using UnityEngine;
using System.Collections;

public class colorfade : MonoBehaviour {

    public Camera mainCam;
    private float startTime;
    public float duration = 2f;

	// Use this for initialization FOR kiki fudlkjj;vlF
	void Start () {
        startTime = Time.time;
        lerpedColor = mainCam.backgroundColor;
        targetColor = new Color(Random.Range(0.8f, 1f), Random.Range(0.8f, 1f), Random.Range(0.8f, 1f));
	}

    public Color lerpedColor;
    public Color targetColor = new Color(0.01f, 0.7f, 0.02f);
    void Update()
    {
        if (Time.time - startTime > duration)
        {
            startTime = Time.time;
            lerpedColor = targetColor;
            targetColor = new Color(Random.Range(0.8f, 1f), Random.Range(0.8f, 1f), Random.Range(0.8f, 1f));
        }
        else
        {
            lerpedColor = Color.Lerp(lerpedColor, targetColor, (Time.time - startTime) / duration);
        }
        mainCam.backgroundColor = lerpedColor;
    }
}
