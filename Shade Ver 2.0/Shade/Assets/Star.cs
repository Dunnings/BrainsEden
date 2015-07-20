using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.Instance.RewardStar();
        gameObject.SetActive(false);
    }
}
