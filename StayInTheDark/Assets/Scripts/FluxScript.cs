using UnityEngine;
using System.Collections;

public class FluxScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.localScale = new Vector3(Time.deltaTime * 100.0f, transform.localScale.y, transform.localScale.z);
	}
}
