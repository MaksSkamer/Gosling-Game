using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Collectable
{
    public GameObject Track;
    public GameObject Exp;
 
    protected override void Start()
    {
        base.Start();
    }
    protected override void OnCollectpl()
    {
        base.OnCollectpl();              
        
        Track = Instantiate(Track) as GameObject;
        Track.transform.position = transform.position;

        Exp = Instantiate(Exp) as GameObject;
        Exp.transform.position = transform.position;

        Destroy(gameObject);
    }
}
