using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float cooldown = 25f;
    private float lastshoot;

    private Animator anim;
    private Animator animFBlow;
    private Animator animSBlow;
    private Animator animTrack;
    private Animator animRuby;
    private Animator camAN;
    protected AudioSource a;
    public AudioClip[] sound;

    void Start()
    {
        anim = GetComponent<Animator>();
        animFBlow = transform.GetChild(0).GetComponent<Animator>();
        animSBlow = transform.GetChild(1).GetComponent<Animator>();
        animTrack = transform.GetChild(2).GetComponent<Animator>();
        animRuby = transform.GetChild(3).GetComponent<Animator>();
        a = GetComponent<AudioSource>();
        a.volume = 0.7f;
        camAN = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();     
    }

    void Update()
    {
        if (Time.time - lastshoot > cooldown)
        {
            lastshoot = Time.time;
            animRuby.Play("Ruby_sparks");
            GameManager.instance.Sound(a, sound, 0);
            Invoke("LaserShoot", 1.9f);
            Invoke("DefualtState", 3.2f);
        }
    }

    void LaserShoot()
    {
        anim.Play("Laser_attack_small");
        animFBlow.Play("FirstBlow");
        animTrack.Play("Track_motion_small");
        animSBlow.Play("EndBlow_small");
    }

    void DefualtState()
    {
        camAN.Play("Camera_idle");
        anim.Play("Laser_idle");
        animFBlow.Play("FirstBlow_idle");
        animTrack.Play("Track_idle");
        animSBlow.Play("EndBlow_idle");
        animRuby.Play("Ruby_idle");
    }
}
