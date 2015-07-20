using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private float xVel;
    private float yVel;

    private float xVelMax = 10.0f;
    private float yVelMax = 10.0f;

    private float xVelRes = 0.0001f;
    private float yVelRes = 0.0001f;

    private float playerWidth = 50f;
    private float playerHeight = 50f;

    private float xTiltMultiplier = 2.0f;
    private float yTiltMultiplier = 2.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        //Input
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight(1.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft(1.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveDown(1.0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveUp(1.0f);
        }
        if (Input.acceleration.x > 0.25f)
        {
            MoveRight(Input.acceleration.x * xTiltMultiplier);
        }
        if (Input.acceleration.x < -0.25f)
        {
            MoveRight(Input.acceleration.x * xTiltMultiplier);
        }
        if (Input.acceleration.y > 0.25f)
        {
            MoveUp(Input.acceleration.x * yTiltMultiplier);
        }
        if (Input.acceleration.y < -0.25f)
        {
            MoveUp(Input.acceleration.x * yTiltMultiplier);
        }

        float widthRel = (this.transform.localScale.x * playerWidth)  / (Screen.width) / 2; //relative width
        float heightRel = (this.transform.localScale.y * playerHeight) / (Screen.height) / 2; //relative height

        //Movement
        Vector3 pos = this.gameObject.transform.position;

        pos.x += xVel * Time.deltaTime;
        pos.y += yVel * Time.deltaTime;
        this.gameObject.transform.position = pos;

        Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, widthRel, 1 - widthRel);
        viewPos.y = Mathf.Clamp(viewPos.y, heightRel, 1 - heightRel);
        this.transform.position = Camera.main.ViewportToWorldPoint(viewPos);

        //Decelaration
        xVel *= Mathf.Pow(xVelRes, Time.deltaTime * 2f);
        yVel *= Mathf.Pow(yVelRes, Time.deltaTime * 2f);
    }

    void MoveRight(float amnt)
    {
        if (xVel < xVelMax)
        {
            xVel += amnt;
        }
    }

    void MoveLeft(float amnt)
    {
        if (xVel > -xVelMax)
        {
            xVel -= amnt;
        }
    }

    void MoveUp(float amnt)
    {
        if (yVel < yVelMax)
        {
            yVel += amnt;
        }
    }

    void MoveDown(float amnt)
    {
        if (yVel > -yVelMax)
        {
            yVel -= amnt;
        }
    }
}
