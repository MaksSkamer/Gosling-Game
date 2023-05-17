using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMusic : MonoBehaviour
{
    protected AudioSource a;
    public AudioClip[] sound;
    public CameraFollow Camera;
    void Start()
    {
        a = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if(Camera.Onplayer == true)
        {
            a.volume = 0.04f;
            a.clip = sound[0];
            GameManager.instance.Sound(a, sound, 0);
        }
        else
        {
            a.volume = 0.15f;
            a.clip = sound[1];
            GameManager.instance.Sound(a, sound, 1);
        }
    }
}
