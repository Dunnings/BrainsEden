using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.Rotate(new Vector3(0, 0, 1), 0.5f);

        //transform.position = new Vector3(Mathf.Sin(Time.time * 0.08f) * 4.0f, transform.position.y, transform.position.z);
    }
}
