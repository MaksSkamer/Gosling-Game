using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudioControlller : MonoBehaviour
{
    private Animator anim;
    private bool dashCD = false;

    protected AudioSource a;
    public AudioClip[] sound;
    void Start()
    {
        anim = GetComponent<Animator>();
        a = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            anim.Play("Player_walk");
            GameManager.instance.Sound(a, sound, 0);
        }
        else
        {
            anim.Play("Player_idle");
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && !dashCD)
        {
            dashCD = true;
            Invoke("dashLock", 1f);
            a.clip = sound[1];
            // anim.SetTrigger("Player_dash");
            GameManager.instance.Sound(a, sound, 1);
        }
    }

    void dashLock()
    {
        dashCD= false;
    }
}
