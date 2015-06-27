using UnityEngine;
using System.Collections;

public class oscillation : MonoBehaviour {

    public float factor = 2.0f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position; 
    }
    
	// Update is called once per frame
	void Update () 
    {
        transform.position = new Vector3(originalPosition.x + (Mathf.Sin(Time.time) * factor), transform.position.y, transform.position.z);

        //transform.position = new Vector3(Mathf.Sin(Time.time) * factor, transform.position.y, transform.position.z);
	}
}
