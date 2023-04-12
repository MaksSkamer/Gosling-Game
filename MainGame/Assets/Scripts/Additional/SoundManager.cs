using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public void PlaySound(AudioSource a, AudioClip[] sound, int i)
    {
        if(!a.isPlaying)
        {
            a.clip = sound[i];
            a.Play();
        }              
    }
}
