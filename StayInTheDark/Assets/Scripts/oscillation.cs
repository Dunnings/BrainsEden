using UnityEngine;
using System.Collections;

public class oscillation : MonoBehaviour {

    public float factor = 2.0f; 

	// Update is called once per frame
	void Update () 
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * factor, transform.position.y, transform.position.z);
	}
}
