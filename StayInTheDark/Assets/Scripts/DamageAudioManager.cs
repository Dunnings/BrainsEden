using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageAudioManager : MonoBehaviour {

    public static DamageAudioManager Instance;

    public List<AudioClip> deathSoundEffect;
    public AudioSource dmgTick;
    public float lastPlay;
    public bool over = false;

    bool doOnce = true;
	// Use this for initialization
	void Start () {
        Instance = this;
	}

    public void RESET()
    {
        over = true;
        doOnce = true;
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
            int ran = Random.Range(0, deathSoundEffect.Count);
            dmgTick.PlayOneShot(deathSoundEffect[ran]);
            doOnce = false;
            over = true;
        }
    }
}
