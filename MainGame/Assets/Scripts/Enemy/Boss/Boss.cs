using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    public RectTransform bossHitpointBar;
    public Image FrameGood;
    public Image FrameBad;
    private float lastRandT;
    public GameObject BossDeath;
    private SpriteRenderer grassie;
    protected override void Start()
    {
        base.Start();
        FrameBad.enabled = false;
        FrameGood.enabled = false;
        Yspeed = 0;
        Xspeed = 0;
        a.volume = 0.5f;
        grassie = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        OnBossHitpointChange();
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

    public void OnBossHitpointChange()
    {
        float ratio = (float)hitpoint / (float)maxHitpoint;
        bossHitpointBar.localScale = new Vector3(ratio, 1, 1);
        if(hitpoint>(40*(maxHitpoint / 100)))
        {
            FrameGood.enabled = true;
        }
        else
        {
            FrameGood.enabled = false;
            FrameBad.enabled = true;
        }

    }
    void BossAttack()
    {
        GameObject Urmom;
    }

    protected override void Death()
    {
        sprite.enabled = false;
        grassie.enabled = false;

        GameObject[] fistsDel = GameObject.FindGameObjectsWithTag("Boss cock");

        foreach (GameObject fist in fistsDel)
        {
            Destroy(fist);
        }

        a.volume = 1f;
        a.clip = sound[2];
        GameManager.instance.Sound(a, sound, 2);
        Invoke("Destruct", 5f);

        BossDeath = Instantiate(BossDeath) as GameObject;
        BossDeath.transform.position = transform.position;        
    }

    void Destruct()
    {
        Destroy(gameObject);
        GameManager.instance.gold += Gold;
        GameManager.instance.Score += Score;
    }
}
