using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{

    protected bool collected;

    protected override void OnCollide(Collider2D col)
    {
        if (col.name == "Player")
        {
            OnCollectpl();
        }
    }

    protected virtual void OnCollectpl()
    {
        collected = true;
    }
}
