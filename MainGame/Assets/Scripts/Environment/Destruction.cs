using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Time;
    public float volume;

    protected AudioSource a;
    public AudioClip[] sound;
    void Start()
    {
        a = GetComponent<AudioSource>();
        a.volume = volume;
        int rand = Random.Range(0, 3);
        GameManager.instance.Sound(a, sound, rand);
        Invoke("Destruct", Time);
    }
    
    void Destruct()
    {
        Destroy(gameObject);
    }
}
