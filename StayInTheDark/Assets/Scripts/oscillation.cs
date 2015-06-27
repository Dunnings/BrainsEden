using UnityEngine;
using System.Collections;

public class oscillation : MonoBehaviour {

    public float factor = 2.0f;
    public bool oscSwitch = false;
    
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position; 
    }
    
	// Update is called once per frame
    void Update()
    {
        if (!oscSwitch)
        {
            transform.position = new Vector3(originalPosition.x + (Mathf.Sin(Time.time) * factor), transform.position.y, transform.position.z);
        }
        else 
        { 
            transform.position = new Vector3(transform.position.x, originalPosition.y + (Mathf.Sin(Time.time) * factor), transform.position.z);
        }
    }
        
}
