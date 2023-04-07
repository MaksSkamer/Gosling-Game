using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    // Души и золото
    public int Gold = 1;
    public int Souls = 1;

    // Переменные для расчёта дистанции между игроком и врагом
    public float triggerLength = 3f;
    public float chaseLength = 10f;
    protected bool chasing;
    private bool colidingWithPlayer;
    public Transform playerTransform;
    protected Vector3 startingposition;

    protected ContactFilter2D filter;
    protected Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        startingposition = transform.position;
    }

    protected void FixedUpdate()
    {
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

            if (hits[i].name == "Player")
            {
                colidingWithPlayer = true;
            }
            hits[i] = null;
        }
    }
}
