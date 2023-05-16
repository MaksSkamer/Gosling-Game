using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMobeYtigger : Collidable
{
    GameObject[] Mobs;
    public string MobTag;
    private int entercount;
    protected override void Start()
    {
        base.Start();       
        Mobs = GameObject.FindGameObjectsWithTag(MobTag);
        foreach (GameObject obj in Mobs)
        {
            obj.SetActive(false);
        }
    }
    protected override void OnCollide(Collider2D col)
    {
        entercount++;
        if (entercount == 1)
        {
            if (col.name == "Player")
            {
                Invoke("DoorLock", 1f);
                foreach (GameObject obj in Mobs)
                {
                    obj.SetActive(true);
                }
            }   
        }
        else if (GameObject.FindGameObjectWithTag(MobTag) == null && entercount > 1)
        {
            Destroy(gameObject);
        }
    }

    void DoorLock()
    {
        boxColider.isTrigger = false;
    }    
}
