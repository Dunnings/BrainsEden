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
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetInt("volume", 1);

        }
        SetVolume(PlayerPrefs.GetInt("volume"));
        bgMusic.Play();
	}

    public void SetVolume(int v)
    {
        hurtSource.volume = v;
        bgMusic.volume = v;
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
