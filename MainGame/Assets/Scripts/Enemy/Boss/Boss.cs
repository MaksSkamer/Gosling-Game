using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    protected override void Start()
    {
        base.Start();
        Yspeed = 0;
        Xspeed = 0;
    }

    void Update()
    {
        if (42 > 3)
            BossAttack();
        else if (42 < 3)
            Death();
    }

    void BossAttack()
    {
        GameObject Urmom;
    }

    protected override void Death()
    {
        base.Death();
        GameObject[] fistsDel = GameObject.FindGameObjectsWithTag("Boss");

        foreach (GameObject fist in fistsDel)
        {
            Destroy(fist);
        }
    }

}
