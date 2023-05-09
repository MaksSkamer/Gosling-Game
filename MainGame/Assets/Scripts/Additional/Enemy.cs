using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;

public class Enemy : Mover
{
    // Души и золото
    public int Gold = 1;
    public int Score = 1;

    // Переменные для расчёта дистанции между игроком и врагом
    public float triggerLength = 3f;
    public float chaseLength = 10f;
    protected bool chasing;
    private bool colidingWithPlayer;
    protected Transform playerTransform;
    protected Vector3 startingposition;

    protected ContactFilter2D filter;
    protected Collider2D[] hits = new Collider2D[10];
    private BoxCollider2D hitbox;
    protected Animator anim;
    protected AudioSource a;
    public AudioClip[] sound;
    protected virtual void Start()
    {
        base.Start();
        startingposition = transform.position;
        playerTransform = GameManager.instance.player.transform;
        //hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        a = GetComponent<AudioSource>();
    }

    protected virtual void FixedUpdate()
    {
        VolumeDistance(Vector3.Distance(playerTransform.position, transform.position));
        if (Vector3.Distance(playerTransform.position, startingposition) < chaseLength)
        {
            if (Vector3.Distance(playerTransform.position, startingposition) < triggerLength)
                chasing = true;

            if (chasing)
            {
           
                if (!colidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingposition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingposition - transform.position);
            chasing = false;
        }

        // При столкновении с игроком
        colidingWithPlayer = false;
        boxColider.Overlap(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].tag == "Figther" && hits[i].name == "Player")
            {
                colidingWithPlayer = true;
            }
            hits[i] = null;
        }
    }

    void VolumeDistance(float dist)
    {
        a.volume = (60-dist) / 60;
    }
    protected override void Death()
    {
        Destroy(gameObject);

        GameManager.instance.gold += Gold;
        GameManager.instance.Score += Score;
    }
}
