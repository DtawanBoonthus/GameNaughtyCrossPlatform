using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SoundClip
{
    public Sound sound;
    public AudioClip audioClip;
    [Range(0, 1)] public float soundVolume;
    public bool loop = false;
    [HideInInspector] public AudioSource audioSource;

    public enum Sound
    {
        BGM,
        Click,
        Fire,
        Walk
    }
}
