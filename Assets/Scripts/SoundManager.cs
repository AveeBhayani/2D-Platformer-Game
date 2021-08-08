using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance {  get { return instance; } }

    public AudioSource Background;
    public AudioSource Effects;
    public SoundType[] Sound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic(Sounds.Music);
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            Background.clip = clip;
            Background.Play();
        }
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            Effects.PlayOneShot(clip);
        }
    }

    public AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sound, i => i.Soundtype == sound);
        
            if (item != null)
            {
            return item.SoundClip;
            }
            return null;              
    }
}

[Serializable]
public class SoundType
{
    public Sounds Soundtype;
    public AudioClip SoundClip;
}

 public enum Sounds
{
    Music,
    ButtonClick,
    PlayerRun,
    PlayerAttack,
    PlayerDeath,
    BossDeath,
    EnemyAttack
}