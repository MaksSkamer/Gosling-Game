using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brabir : Enemy
{
    private float rrrCD = 7f;
    private float lastrrr;
    private bool attack = false;
    private bool lockpoz;
    private Vector2 lockpos;
    private bool Dead = false;
    private Animator potAnim;
    private BoxCollider2D colider;
    private BoxCollider2D Childcolider;
    protected void Start()
    {
        base.Start();
        potAnim = transform.GetChild(0).GetComponent<Animator>();
        colider = GetComponent<BoxCollider2D>();
        Childcolider = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    protected override void FixedUpdate()
    {  
        base.FixedUpdate();
        if(Vector3.Distance(playerTransform.position, transform.position) <= 14 && !attack && !Dead)
        {
            attack = true;
            lockpos = transform.position;
            lockpoz = true;           
            Invoke("NormalMode", 4f);
            Yspeed = 0;
            Xspeed = 0;          
        }

        if (lockpoz && !Dead)
        {
            transform.position = lockpos;
            potAnim.Play("Brabir_potion_attack");
            anim.Play("Brabir_idle");
            int randPot = Random.Range(4, 5);
            GameManager.instance.Sound(a, sound, randPot);
        }
        else if(!lockpoz && !Dead && chasing)
        {
            potAnim.Play("Brabir_potion_idle");
            anim.Play("Brabir_walk");
            int rand = Random.Range(0, 3);
            GameManager.instance.Sound(a, sound, rand);
        }

        if (Time.time - lastrrr > rrrCD && !Dead)
        {
            lastrrr= Time.time;
            if (GameManager.instance.fch < 50)
            {
                a.clip = sound[6];
                GameManager.instance.Sound(a, sound, 6);
            }
        }

       if(!chasing && !Dead)
            anim.Play("Brabir_idle");
    }
    void NormalMode()
    {
        Yspeed = 7;
        Xspeed = 5;
        attack = false;
        lockpoz = false;
    }

    protected override void UpdateMotor(Vector3 input)
    {
        base.UpdateMotor(input);

        if (moveVector.x < 0)
            transform.localScale = new Vector3(0.62f, 0.62f, 0.62f);
        else if (moveVector.x > 0)
            transform.localScale = new Vector3(-0.62f, 0.62f, 0.62f);
    }

    protected override void Death()
    {
        Dead = true;
        colider.enabled = false;
        Childcolider.enabled = false;
        sprite.enabled= false;       
        chasing = false;
        Yspeed = 0;
        Xspeed = 0;
        a.clip = sound[7];
        GameManager.instance.Sound(a, sound, 7);
        Invoke("Destruct", 5f);
    }

    void Destruct()
    {
        Destroy(gameObject);
        GameManager.instance.gold += Gold;
        GameManager.instance.Score += Score;
    }
}
