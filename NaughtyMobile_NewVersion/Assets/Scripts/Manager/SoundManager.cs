using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonPersistent<SoundManager>
{
    [SerializeField] private SoundData soundData;
    
    public override void Awake()
    {
        base.Awake();
        Play(SoundClip.Sound.BGM);
    }
    
    public void Play(SoundClip.Sound sound)
    {
        var soundClip = GetSoundClip(sound);
        if (soundClip.audioSource == null)
        {   
            soundClip.audioSource = gameObject.AddComponent<AudioSource>();
        }
        soundClip.audioSource.clip = soundClip.audioClip;
        soundClip.audioSource.volume = soundClip.soundVolume;
        soundClip.audioSource.loop = soundClip.loop;
        soundClip.audioSource.Play();
    }
    
    public void Stop(SoundClip.Sound sound)
    {
        var soundClip = GetSoundClip(sound);

        soundClip.audioSource.Stop();
    }

    private SoundClip GetSoundClip(SoundClip.Sound sound)
    {
        foreach (var soundClip in soundData.soundClips)
        {
            if (soundClip.sound == sound)
            {
                return soundClip;
            }
        }
        return null;
    }
}
