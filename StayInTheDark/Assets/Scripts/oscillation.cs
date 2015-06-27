using UnityEngine;
using System.Collections;

public class oscillation : MonoBehaviour {

<<<<<<< HEAD
    public float factor = 1.0f;
    public float minX = -5f;
    public float maxX = 5f;

=======
    public float factor = 2.0f;
    public bool oscSwitch = false;
    
>>>>>>> origin/master
    private Vector3 originalPosition;
    private Vector3 maxPosition;
    private Vector3 minPosition;
    private bool toMax = true;

    void Start()
    {
        originalPosition = transform.position;
        maxPosition = new Vector3(originalPosition.x + maxX, originalPosition.y, originalPosition.z);
        minPosition = new Vector3(originalPosition.x + minX, originalPosition.y, originalPosition.z);
    }
    
	// Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (Level.level.gameState == Level.GameState.PLAYING)
        {
            if (toMax)
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
                if (transform.position.x >= minPosition.x)
                {
                    transform.position = new Vector3(transform.position.x - (Time.deltaTime * factor), transform.position.y, transform.position.z);
                }
                else
                {
                    toMax = true;
                }
            }
            
        }
        //transform.position = new Vector3(Mathf.Sin(Time.time) * factor, transform.position.y, transform.position.z);
	}
=======
        if (!oscSwitch)
        {
            transform.position = new Vector3(originalPosition.x + (Mathf.Sin(Time.time) * factor), transform.position.y, transform.position.z);
        }
        else 
        { 
            transform.position = new Vector3(transform.position.x, originalPosition.y + (Mathf.Sin(Time.time) * factor), transform.position.z);
        }
    }
        
>>>>>>> origin/master
}
