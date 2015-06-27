using UnityEngine;
using System.Collections;

public class DamageAudioManager : MonoBehaviour {

    public static DamageAudioManager Instance;

    public AudioClip deathSoundEffect;
    public AudioSource dmgTick;
    public float lastPlay;
    public bool over = false;

    bool doOnce = true;
	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (!over && Time.time - lastPlay > 0.1f)
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

    public void deathSound()
    {
        if (doOnce)
        {
            dmgTick.Stop();
            dmgTick.PlayOneShot(deathSoundEffect);
            doOnce = false;
            over = true;
        }
    }
}
