using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public Sound[] musicSounds, sfsSounds;
    public AudioSource musicSource, sfxSourse;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        PlayMusic("Theme");
    }
    public void PlayMusic(string name)
    {

        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not found: "+name);
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfsSounds, x => x.name == name);
        if (s != null)
        {
            Debug.Log("sfx Not found");
        }
        else
        {
            sfxSourse.PlayOneShot(s.clip);
        }
    }
}
