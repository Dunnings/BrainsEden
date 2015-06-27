using UnityEngine;
using System.Collections;

public class oscillation : MonoBehaviour {

    public float factor = 1.0f;
    public float minX = -5.0f;
    public float maxX = 5.0f;
    public float minY = -5.0f;
    public float maxY = 5.0f;

    public bool _switch = false;


    private Vector3 originalPosition;
    private Vector3 maxPosition;
    private Vector3 minPosition;

    private Vector3 maxPositionY;
    private Vector3 minPositionY;
    private bool toMax = true;

    void Start()
    {
        originalPosition = transform.position;
        maxPosition = new Vector3(originalPosition.x + maxX, originalPosition.y, originalPosition.z);
        minPosition = new Vector3(originalPosition.x + minX, originalPosition.y, originalPosition.z);

        maxPositionY = new Vector3(originalPosition.y, originalPosition.y + maxY, originalPosition.z);
        minPositionY = new Vector3(originalPosition.y, originalPosition.y + minY, originalPosition.z);
    }
    
	// Update is called once per frame
    void Update()
    {

        if (Level.level.gameState == Level.GameState.PLAYING)
        {
            if (toMax)
            {
                if (!_switch)
                {
                    if (transform.position.x <= maxPosition.x)
                    {
                        transform.position = new Vector3(transform.position.x + (Time.deltaTime * factor), transform.position.y, transform.position.z);
                    }
                    else
                    {
                        toMax = false;
                    }
                }
                else
                {
                    if (transform.position.y <= maxPositionY.y)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + (Time.deltaTime * factor), transform.position.z);
                    }
                    else
                    {
                        toMax = false;
                    }

                }
            }
            else
            {
                if (!_switch)
                {
                    if (transform.position.x >= minPosition.x)
                    {
                        transform.position = new Vector3(transform.position.x - (Time.deltaTime * factor), transform.position.y, transform.position.z);
                    }
                    else
                    {
                        toMax = true;
                    }
                }
                else
                {
                    if (transform.position.y >= minPositionY.y)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - (Time.deltaTime * factor), transform.position.z);
                    }
                    else
                    {
                        toMax = true;
                    }
                }
              
            }
        }
        //transform.position = new Vector3(Mathf.Sin(Time.time) * factor, transform.position.y, transform.position.z);
	}

}
