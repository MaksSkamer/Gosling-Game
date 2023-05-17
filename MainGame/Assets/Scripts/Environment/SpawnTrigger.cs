using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : Collidable
{
    GameObject[] BossObj;
    GameObject Bos;
    public CameraFollow Camera;
    private int countEnter;
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
        countEnter++;
        if (countEnter == 1)
        {
            Camera.Onplayer = false;
            if (col.name == "Player")
            {
                Invoke("DoorLock", 2f);
                Bos.SetActive(true);
                foreach (GameObject obj in BossObj)
                {
                    obj.SetActive(true);
                }
            }
        }                
    }

    void DoorLock()
    {
        boxColider.isTrigger = false;
    }
}


