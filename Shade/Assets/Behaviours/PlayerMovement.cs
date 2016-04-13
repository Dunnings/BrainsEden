using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private float speed = 0.1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (Input.acceleration.x > 0.08f || Input.acceleration.x < -0.08f || Input.acceleration.y > 0.08f || Input.acceleration.y < -0.08f)
        {
            float x = Input.acceleration.x;
            float y = Input.acceleration.y;
            float z = Input.acceleration.z;
            if (x > 0.5f) { x = 0.5f; }
            if (x < -0.5f) { x = -0.5f; }
            if (y > 0.5f) { y = 0.5f; }
            if (y < -0.5f) { y = -0.5f; }
            x *= 2f;
            y *= 2f;
            Vector3 translate = new Vector3(x, y, 0f);
            transform.Translate(translate * speed);
        }
        
        if (Input.GetButton("Horizontal"))
        {
            transform.Translate(new Vector3((Input.GetAxis("Horizontal") * speed), 0.0f, 0.0f));
        }
        if (Input.GetButton("Vertical"))
        {
            transform.Translate(new Vector3(0.0f, (Input.GetAxis("Vertical") * speed), 0.0f));
        }


    }
}
