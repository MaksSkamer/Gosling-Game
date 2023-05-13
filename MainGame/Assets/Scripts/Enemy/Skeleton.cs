using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    protected void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        anim.Play("Skeleton_walk");
        if (Vector3.Distance(playerTransform.position, transform.position) <= 15)
        {
            Yspeed = 19;
            Xspeed = 17;
            anim.speed = 7;
        }
        else
        {
            Yspeed = 5;
            Xspeed = 4;
            anim.speed = 0.8f;
        }
 
    }
}
