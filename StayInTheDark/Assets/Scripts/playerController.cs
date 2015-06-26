using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour 
{
    public float speed = 2.5f; 

	// Update is called once per frame
	void Update () 
    {
        move();

	
	}

    void move()
    {
        Vector3 translate = new Vector3(Input.acceleration.x, Input.acceleration.y, -Input.acceleration.z);
        transform.Translate(translate * speed * Time.deltaTime);



        if (Input.GetButtonDown("Horizontal"))
        {
            transform.Translate(new Vector3((Input.GetAxis("Horizontal") * speed * Time.deltaTime), 0.0f, 0.0f));
        }
        else if (Input.GetButtonDown("Horizontal"))
        {
            transform.Translate(new Vector3( 0.0f,(Input.GetAxis("Horizontal") * speed * Time.deltaTime), 0.0f));
        }
    }
}
