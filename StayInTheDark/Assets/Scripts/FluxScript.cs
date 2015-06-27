using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FluxScript : MonoBehaviour {

    private float startXScale;

	// Use this for initialization
    void Start()
    {
        startXScale = this.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.localScale = new Vector3(startXScale + Random.Range(0f,0.5f), transform.localScale.y, transform.localScale.z);
	}
}