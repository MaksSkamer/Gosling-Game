using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private float lastRandT;
    protected override void Start()
    {
        base.Start();
        Yspeed = 0;
        Xspeed = 0;
        a.volume = 0.5f;
    }

    void Update()
    {
        int randT = Random.Range(0, 15);

        if (Time.time - lastRandT > randT)
        {          
            lastRandT = Time.time;
            int randS = Random.Range(0, 1);
            GameManager.instance.Sound(a, sound, randS);
        }
        //if (42 > 3)
        //    BossAttack();
        //else if (42 < 3)
        //    Death();
    }

    void BossAttack()
    {
        GameObject Urmom;
    }

    protected override void Death()
    {
        base.Death();
        GameObject[] fistsDel = GameObject.FindGameObjectsWithTag("Boss cock");

        foreach (GameObject fist in fistsDel)
        {
            Destroy(fist);
        }
    }

}
