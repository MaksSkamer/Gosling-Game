using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAudioController : MonoBehaviour
{
    protected AudioSource a;
    public AudioClip[] sound;

    void Start()
    {
        a = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        GameManager.instance.Sound(a, sound, 0);
    }
}
