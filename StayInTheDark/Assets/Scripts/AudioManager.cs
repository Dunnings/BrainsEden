using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;

    public List<AudioClip> deathSoundEffect;
    public AudioSource hurtSource;
    public AudioSource bgMusic;

    public float lastPlay;
    public bool over = false;

    bool doOnce = true;
	// Use this for initialization
	void Start () {
        Instance = this;
        bgMusic.Play();
	}

    public void RESET()
    {
        over = true;
        doOnce = true;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void deathSound()
    {
        int ran = Random.Range(0, deathSoundEffect.Count);
        hurtSource.PlayOneShot(deathSoundEffect[ran]);
    }
}
