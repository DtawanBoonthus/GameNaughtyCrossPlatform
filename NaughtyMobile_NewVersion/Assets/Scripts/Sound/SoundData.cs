using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "Sound")]
public  class SoundData : ScriptableObject
{
    public List<SoundClip> soundClips = new List<SoundClip>();
}
