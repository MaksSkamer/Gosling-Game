using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFist : Fist
{
    
    protected void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        if (GameManager.instance.fch > 50)
            Conditions();
    }
}
