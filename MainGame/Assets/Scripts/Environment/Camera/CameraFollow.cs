using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool Onplayer = true;
    private Camera cam;
    private Transform target;
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        cam = GetComponent<Camera>();
    }

 
    void Update()
    {
        if (Onplayer)
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        else
        {
            transform.transform.position = new Vector3(368.2f, -63.3f, 0f);
            cam.orthographicSize = 50f;
        }

    }
}
