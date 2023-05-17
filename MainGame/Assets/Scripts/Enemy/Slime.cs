using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    private bool Isjump;
    private float jumpCD = 2f;
    private float lastjump;
    protected void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (Time.time - lastjump > jumpCD)
        {
            lastjump = Time.time;
            jump();
        }
        else

        if (Isjump) 
        {
            Yspeed = 16;
            Xspeed = 14;
        }
        else
        {
            Yspeed = 0;
            Xspeed = 0;
            anim.Play("Slime_idle");
        }
    }

    void jump()
    {
        Isjump = true;
        anim.Play("Slime_jump");
        Invoke("jumpoff", 0.8f);
    }

    void jumpoff()
    {
        int rand = Random.Range(0, 10);
        GameManager.instance.Sound(a, sound, rand);
        Isjump = false;
    }
}
