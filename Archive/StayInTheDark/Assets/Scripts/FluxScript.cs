using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FluxScript : MonoBehaviour {

    private Vector3 startXScale;
    private Vector3 endXScale;
    private float startTime = 0f;
    private float transition = 2f;
    public bool expand = true;

	// Use this for initialization
    void Start()
    {
        startTime = Time.time;
        startXScale = this.transform.localScale;
        endXScale = new Vector3(this.transform.localScale.x + 0.3f, this.transform.localScale.y, this.transform.localScale.z);


        
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - startTime > transition)
        {
            startTime = Time.time;
            expand = !expand;
        }
        if (expand)
        {
            this.transform.localScale = Vector3.Lerp(startXScale, endXScale, (Time.time - startTime) / transition);
        }
        else
        {
            this.transform.localScale = Vector3.Lerp(endXScale, startXScale, (Time.time - startTime) / transition);
        }
	}
}