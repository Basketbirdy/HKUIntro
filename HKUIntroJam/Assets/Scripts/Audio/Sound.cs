using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.PlayerLoop;

[System.Serializable]
public class Sound
{
    [Header("Description")]
    public string soundName;
    public string soundDescription;

    [Header("Data")]
    public AudioClip clip;
    [Space]
    [Range(0,1)] public float volume;
    public bool loops = false;

    [HideInInspector] public AudioSource source;
}
