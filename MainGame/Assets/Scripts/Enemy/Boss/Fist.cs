using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Fist : MonoBehaviour
{
    public Transform player;

    private Animation anim;
    private Vector3 input;
    private Vector3 startingposition;
    private float offset;
    private bool attack = false;
    private float lastpunch;
    private float cooldown = 5f;
    void Start()
    {
        anim = GetComponent<Animation>();
        startingposition= transform.position;
    }

    private void Update()
    {

        if (Time.time - lastpunch > cooldown)
        {
            Debug.Log("Новый удар");
            lastpunch = Time.time;
            offset = Vector3.Distance(transform.position, player.transform.position) / 50f;
            input = player.transform.position - transform.position;
            input = new Vector3(input.x, input.y + 15, input.z);
        }
        if(transform.position != input)
        {
            Debug.Log("[");
            transform.Translate(input.x * Time.deltaTime * offset, input.y * Time.deltaTime * offset, 0);
        }
        if(Mathf.Round(transform.position.x) == Mathf.Round(player.transform.position.x) && !attack)
        {
            Debug.Log("]");
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 15, player.transform.position.z);
            attack = true;          
            Punch();
        }
    }

    void Punch()
    {
        Debug.Log("УДар");
        anim.SetTrigger("poop");
        Invoke("Return",1f);
        attack = false;
    }
    void Return()
    {
        transform.Translate(startingposition.x * Time.deltaTime * offset, startingposition.y * Time.deltaTime * offset, 0);
    }

}
