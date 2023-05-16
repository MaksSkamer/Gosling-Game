using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    protected BoxCollider2D boxColider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        boxColider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        boxColider.Overlap(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            OnCollide(hits[i]);

            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D col)
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {

    }
}
