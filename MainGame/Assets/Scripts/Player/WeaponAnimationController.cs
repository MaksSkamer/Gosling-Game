using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationController : MonoBehaviour
{
    private Animator weapAnim;
    void Start()
    {
        weapAnim= GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            weapAnim.SetBool("isRunning", true);
        }
        else
        {
            weapAnim.SetBool("isRunning", false);
        }
    }
}
