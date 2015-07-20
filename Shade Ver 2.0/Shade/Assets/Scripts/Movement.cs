using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public Vector3 startPos;
    public Vector3 endPos;

    public bool oscillate = true;
    public float animTime = 3f;

    private float totalTime = 0f;

	void Start () {
        transform.position = startPos;
	}
	
	void Update () {
        if (transform.position != endPos)
        {
            transform.position = Vector3.Lerp(startPos, endPos, totalTime / animTime);
        }
        else
        {
            if (oscillate)
            {
                endPos = startPos;
                startPos = transform.position;
            }
            totalTime = 0f;
        }
        totalTime += Time.deltaTime;
	}
}
