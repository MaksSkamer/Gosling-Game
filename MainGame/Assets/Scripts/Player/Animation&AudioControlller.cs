using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudioControlller : MonoBehaviour
{
    private Animator anim;
    private bool dashCD = false;

    protected AudioSource a;
    public AudioClip[] sound;
    private Animator animShad;
    void Start()
    {
        animShad = transform.GetChild(1).GetComponent<Animator>();
        anim = GetComponent<Animator>();
        a = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            a.volume = 0.8f;
            anim.Play("Player_walk");
            animShad.Play("Player_shadow_motion");
            GameManager.instance.Sound(a, sound, 0);
        }
        else
        {
            animShad.Play("Player_shadow_idle");
            anim.Play("Player_idle");
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && !dashCD)
        {
            a.volume = 0.6f;
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
