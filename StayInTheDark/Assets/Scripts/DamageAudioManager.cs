using UnityEngine;
using System.Collections;

public class DamageAudioManager : MonoBehaviour {

    public static DamageAudioManager Instance;

    public AudioSource dmgTick;
    public float lastPlay;

	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - lastPlay > 0.1f)
        {
            dmgTick.Pause();
        }
	}

    public void playDamageSound(float percent)
    {
        lastPlay = Time.time;
        if (!dmgTick.isPlaying)
        {
            dmgTick.Play();
        }

    }
}
