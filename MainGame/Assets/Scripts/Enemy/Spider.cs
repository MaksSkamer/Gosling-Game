using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private bool attack = false;
    private bool Enddash = false;
    private bool lockpoz = false;
    private bool movementControl;
    private Vector2 lockpos;
    public float dashImpulse;
    private Rigidbody2D rb;
    private float screamCD = 7f;
    private float lastScream;
    protected void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(!movementControl)
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (chasing)
        {
            GameManager.instance.Sound(a, sound, 0);
            if (Time.time - lastScream > screamCD)
            {
                lastScream= Time.time;
                if (GameManager.instance.fch > 50)
                {
                    a.clip = sound[4];
                    GameManager.instance.Sound(a, sound, 4);
                }
            }
            
                
        }
            

        if (Vector3.Distance(playerTransform.position, transform.position) <= 5 && !attack)
        {
                lockpoz= true;
                lockpos = transform.position;
                Attack();
        }
        if (lockpoz)
            transform.position = lockpos;
    }
    private void Attack()
    {      
        attack = true;
        movementControl = true;
        anim.Play("Spider_jump");
        Invoke("Dash", 1f);       
        Invoke("AttackLock", 7f);
    }

    private void AttackLock()
    {
        attack = false;
        Enddash= false;       
    }

    void Dash()
    {
        int rand = Random.Range(1, 3);
        a.clip = sound[rand];
        GameManager.instance.Sound(a, sound, rand);
        Invoke("dashLock", 0.05f);
        lockpoz = false;
        if (moveVector.x < 0 && !Enddash)
            rb.velocity = new Vector2(-dashImpulse, rb.velocity.y);
        else if(moveVector.x > 0 && !Enddash)
            rb.velocity = new Vector2(dashImpulse, rb.velocity.y);      
    }

    void dashLock()
    {
        Enddash= true;
        movementControl = false;
        rb.velocity = Vector2.zero;
    }    
}

