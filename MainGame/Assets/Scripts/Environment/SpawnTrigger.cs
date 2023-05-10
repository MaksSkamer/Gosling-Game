using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : Collidable
{
    GameObject[] BossObj;
    GameObject Bos;
    protected override void Start()
    {
        base.Start();
        Bos = GameObject.FindGameObjectWithTag("Boss");
        BossObj = GameObject.FindGameObjectsWithTag("Boss cock");       
        foreach (GameObject obj in BossObj)
        {
            obj.SetActive(false);
        }
        Bos.SetActive(false);
    }
    protected override void OnCollide(Collider2D col)
    {
        if(col.name == "Player")
        {
            
            Bos.SetActive(true);
            foreach (GameObject obj in BossObj)
            {
                obj.SetActive(true);
            }
        }
    }
}


