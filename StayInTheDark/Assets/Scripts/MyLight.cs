using UnityEngine;
using System.Collections;

public class MyLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position += new Vector3(0.2f * Time.deltaTime, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0.2f * Time.deltaTime, 0.0f, 0.0f);
	}
}
