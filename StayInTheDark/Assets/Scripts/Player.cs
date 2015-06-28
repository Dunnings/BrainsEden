using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    public Vector3 startPos;

    public static Player Instance;
    public Text t;
    public Text deathText;

    public int maxHealth = 100;
    public int currentHealth = 100;

    float lastDamaged;
    float immunity = 0.02f;

    private float playerDeaths = 0;

    
    
	// Use this for initialization
	void Start ()
    {
        Instance = this;
        lastDamaged = Time.time;
        startPos = this.transform.position;
	}	

    public void Damage(int amnt)
    {
        //if (currentHealth > 0)
        //{
        //    if (Time.time - lastDamaged > immunity)
        //    {
        //        //Debug.Log((float)((float)currentHealth / (float)maxHealth));
        //        DamageAudioManager.Instance.playDamageSound((float)((float)currentHealth / (float)maxHealth));
        //        currentHealth = Mathf.Max(0, currentHealth - amnt);
        //        t.text = currentHealth.ToString();
        //        lastDamaged = Time.time;
        //    }
        //}
        //else
        //{
        playerDeaths++;
        deathText.text = "Deaths: " + playerDeaths;
        AudioManager.Instance.deathSound();
        Level.level.gameState = Level.GameState.FAIL;
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Level.level.gameState = Level.GameState.WIN;
    }

    public void RESET()
    {
        transform.position = startPos;
        currentHealth = maxHealth;
        lastDamaged = Time.time;
    }
}
