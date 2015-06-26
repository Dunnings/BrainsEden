using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightManager : MonoBehaviour {

    public GameObject player;
    public List<GameObject> allLights; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public bool isInAnyLight(GameObject player, List<GameObject> allLights)
    {
        bool isInAny = false;
        for (int i = 0; i < allLights.Count; i++)
        {
            if (isInLight(player, allLights[i]))
            {
                isInAny = true;
            }
        }
        return isInAny;
    }

    private bool isInLight(GameObject player, GameObject light){
        RaycastHit2D newHit = Physics2D.Raycast(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(light.transform.position.x, light.transform.position.y));
        return (newHit.collider != null);
    }
}
