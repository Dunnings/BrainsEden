using UnityEngine;
using System.Collections;
using EaseyEase;

public class Movement : MonoBehaviour {

    bool oscillate = true;
    public Vector3 min;
    public Vector3 max;
    public float travelTime = 1f;

    EaseyTimer timer;

	// Use this for initialization
	void Start () {
        timer = new EaseyTimer(travelTime, EaseyTimer.repeatType.pingPong);
	}
	
	// Update is called once per frame
	void Update () {
        if (oscillate)
        {
             transform.position = Easey.Ease(Easey.EaseType.QuadInOut, min, max, timer);
        }
	}
}
