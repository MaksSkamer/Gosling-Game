using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Skeleton : Enemy
{
    private Animator shadow;
    private float soundCD = 7f;
    private float lastSound;
    private SpriteRenderer spritesh;
    private bool Dead = false;
    private BoxCollider2D colider;
    private BoxCollider2D Childcolider;
    protected void Start()
    {
        base.Start();
        shadow = transform.GetChild(1).GetComponent<Animator>();
        spritesh = transform.GetChild(1).GetComponent<SpriteRenderer>();
        colider = GetComponent<BoxCollider2D>();
        Childcolider = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    protected override void FixedUpdate()
    {
        if (chasing)
            shadow.Play("Skeleton_shadow_motion");
        else
            shadow.Play("Skeleton_shadow_idle");

        base.FixedUpdate();
        anim.Play("Skeleton_walk");
        if (Vector3.Distance(playerTransform.position, transform.position) <= 15 && !Dead)
        {
            a.clip = sound[1];
            GameManager.instance.Sound(a, sound, 1);
            Yspeed = 19;
            Xspeed = 17;
            anim.speed = 7;
            shadow.speed = 6f;
        }
        else if (Vector3.Distance(playerTransform.position, transform.position) >= 15 && !Dead)
        {
            a.clip = sound[0];
            GameManager.instance.Sound(a, sound, 0);
            Yspeed = 5;
            Xspeed = 4;
            anim.speed = 0.8f;
            shadow.speed = 1f;
        }

        if (Time.time - lastSound > soundCD && !Dead)
        {
            lastSound = Time.time;
            if (GameManager.instance.fch > 50)
            {
                int rand = Random.Range(3, 5);
                a.clip = sound[rand];
                GameManager.instance.Sound(a, sound, rand);
            }
        }

    }

    protected override void UpdateMotor(Vector3 input)
    {
        base.UpdateMotor(input);

        if (moveVector.x < 0)
            transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        else if (moveVector.x > 0)
            transform.localScale = new Vector3(-0.6f, 0.6f, 0.6f);
    }

    protected override void Death()
    {
        Dead = true;
        colider.enabled = false;
        Childcolider.enabled = false;
        chasing = false;
        Yspeed = 0;
        Xspeed = 0;
        a.clip = sound[2];
        GameManager.instance.Sound(a, sound, 2);
        sprite.enabled = false;
        spritesh.enabled = false;
        Invoke("Destruct", 3f);
    }

    void Destruct()
    {
        Destroy(gameObject);
        GameManager.instance.gold += Gold;
        GameManager.instance.Score += Score;
    }
}
