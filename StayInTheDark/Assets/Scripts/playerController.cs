using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
    public float speed = 10f;
    // Update is called once per frame
    void Update()
    {
        if (Level.level.gameState == Level.GameState.PLAYING)
        {
            move();
        }
    }

    void move()
    {
        Vector3 translate = new Vector3(Input.acceleration.x, Input.acceleration.y, -Input.acceleration.z);
        transform.Translate(translate * speed * Time.deltaTime);

        if (Input.GetButton("Horizontal"))
        {
            transform.Translate(new Vector3((Input.GetAxis("Horizontal") * speed * 0.5f * Time.deltaTime), 0.0f, 0.0f));
        }
        if (Input.GetButton("Vertical"))
        {
            transform.Translate(new Vector3(0.0f, (Input.GetAxis("Vertical") * speed * 0.5f * Time.deltaTime), 0.0f));
        }

    }
}