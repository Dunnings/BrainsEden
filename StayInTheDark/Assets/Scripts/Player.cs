using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    public Text t;

    public int maxHealth = 100;
    public int currentHealth = 100;

    float lastDamaged;
    float immunity = 0.05f;


	// Use this for initialization
	void Start () {
        lastDamaged = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Damage(int amnt)
    {
        if (currentHealth > 0)
        {
            if (Time.time - lastDamaged > immunity)
            {
                //Debug.Log((float)((float)currentHealth / (float)maxHealth));
                DamageAudioManager.Instance.playDamageSound((float)((float)currentHealth / (float)maxHealth));
                currentHealth = Mathf.Max(0, currentHealth - amnt);
                t.text = currentHealth.ToString();
                lastDamaged = Time.time;
            }
        }
        else
        {
            DamageAudioManager.Instance.deathSound();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Level.level.gameState = Level.GameState.END;
    }
}
