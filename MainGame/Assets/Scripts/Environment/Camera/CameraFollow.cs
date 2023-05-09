using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        
    }

 
    void Update()
    {
        anim.Play("Camera_idle");
    }
}
