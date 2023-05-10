using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    protected AudioSource a;
    public AudioClip[] sound;
    void Start()
    {
        //a = GetComponent<AudioSource>();
        //InvokeRepeating("Do", 0, 3f);
    }

    private void Do()
    {
        GameManager.instance.Sound(a, sound, 0);
    }

}
