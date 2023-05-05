using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Fist : MonoBehaviour
{
    public Transform player;

    private Animator anim;
    private Animator animDust;
    private Animator animShad;
    private Vector3 input;
    private Vector3 startingposition;
    private float offset = 20;
    private bool attack = false;
    private bool catche = false;
    private bool chasing = false;
    private float lastpunch;
    private float cooldown = 5f;
    private Transform Shadow;
    void Start()
    {
        anim = GetComponent<Animator>();
        startingposition= transform.position;
        animDust = transform.GetChild(1).GetComponent<Animator>();
        animShad = transform.GetChild(0).GetComponent<Animator>();
        Shadow = transform.GetChild(0).GetComponent<Transform>();
    }

    private void Update()
    {
            if (Time.time - lastpunch > cooldown && Vector3.Distance(transform.position, startingposition) < 50)
            {
                lastpunch = Time.time;
                attack = true;
                chasing = true;
            }
            if (chasing)
            {
                input = player.transform.position - transform.position;
                transform.Translate(input.x * Time.deltaTime * offset, (input.y + 11) * Time.deltaTime * offset, 0);
            }
            if (Mathf.Round(transform.position.x) == Mathf.Round(player.transform.position.x) &&
                Mathf.Round(transform.position.y) == Mathf.Round(player.transform.position.y + 11) && attack && !catche)
            {
                chasing = false;
                Vector2 fsState = new Vector2(player.transform.position.x, transform.position.y);
                catche = true;
                transform.position = fsState;
                Invoke("ReturnLock", 1f);
                Punch();
            }
            else if (!attack)
            {
                Return();
            }
            
    }

    void Punch()
    {    
        transform.position += new Vector3(0, -3, 0);
        Shadow.transform.position += new Vector3(0, 6, 0);
        animShad.Play("Shadow_fall");
        anim.Play("Fist_punch");
        Invoke("DustBlow", 0.5f);
    }
    void Return()
    {
        chasing = false;
        Vector3 Back = startingposition - transform.position;
        transform.Translate(Back.x * Time.deltaTime * (offset / 2), Back.y * Time.deltaTime * (offset / 2), 0);
    }

    void DustBlow()
    {
        animDust.SetTrigger("fart");     
    }
    
    void ReturnLock()
    {
        Shadow.transform.position += new Vector3(0, -6, 0);
        anim.Play("Fist_idle");
        animShad.Play("Shadow_idle");
        attack= false;
        catche= false;
    }

}
