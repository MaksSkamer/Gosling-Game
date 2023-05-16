using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : Enemy
{
    protected void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (chasing)
        {
            int rand = Random.Range(0, 1);
            GameManager.instance.Sound(a, sound, rand);
            anim.Play("Gnome_walk");
        }
        else
            anim.Play("Gnome_idle");
    }
}
