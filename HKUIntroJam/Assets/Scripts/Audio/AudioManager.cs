using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    private void Start()
    {

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.loops;
        }

        AudioManager.instance.PlaySound("Game_Spannend_Thema_Bos");
    }

    public void Update()
    {

    }

    public void PlaySound(string clipName)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == clipName);
        s.source.Play();
    }

    public void StopSound(string clipName)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == clipName);
        s.source.Stop();
    }

}
