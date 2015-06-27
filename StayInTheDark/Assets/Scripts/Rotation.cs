using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    public float speed = 2.0f;
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.Rotate(new Vector3(0, 0, 1), speed);

        //transform.position = new Vector3(Mathf.Sin(Time.time * 0.08f) * 4.0f, transform.position.y, transform.position.z);
    }
}
