using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    public Text t;

    public int maxHealth = 100;
    public int currentHealth = 100;

    float lastDamaged;
    float immunity = 0.5f;


	// Use this for initialization
	void Start () {
        lastDamaged = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Damage(int amnt)
    {
        if (Time.time - lastDamaged > immunity)
        {
            currentHealth = Mathf.Max(0, currentHealth - amnt);
            t.text = currentHealth.ToString();
            lastDamaged = Time.time;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Level.level.gameState = Level.GameState.END;
    }
}
