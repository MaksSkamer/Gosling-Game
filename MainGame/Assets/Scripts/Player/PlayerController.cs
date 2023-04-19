using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Mover
{
    public float DashImpulse = 5000;
    private float DashTime = 0.15f;
    private float DashCD = 1f;
    private bool EndDash;
    private bool movementControl;
    private float x;
    private float y;
    private Rigidbody2D rb;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
        EndDash = false;
        movementControl= false;
    }
    private void FixedUpdate()
    {
        GameManager.instance.OnHitpointChange();
        if (movementControl == false)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");

            UpdateMotor(new Vector3(x, y, 0));
        }
        else {  }

        Dash();
    }

    private void Dash()
    {
        if (x < 0 && Input.GetKey(KeyCode.LeftShift) && EndDash == false)
        {
            StartCoroutine(Timer());
            if (EndDash == false)
            {
                rb.velocity = new Vector2(-DashImpulse, rb.velocity.y);
            }
        }
        else if (x > 0 && Input.GetKey(KeyCode.LeftShift) && EndDash == false)
        {
            StartCoroutine(Timer());
            if (EndDash == false)
            {
                rb.velocity = new Vector2(DashImpulse, rb.velocity.y);
            }
        }
        else if (y < 0 && Input.GetKey(KeyCode.LeftShift) && EndDash == false)
        {
            StartCoroutine(Timer());
            if (EndDash == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, -DashImpulse);
            }
        }
        else if (y > 0 && Input.GetKey(KeyCode.LeftShift) && EndDash == false)
        {
            StartCoroutine(Timer());
            if (EndDash == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, DashImpulse);
            }
        }
    }
    IEnumerator Timer()
    {
        EndDash = false;
        movementControl = true;
        yield return new WaitForSeconds(DashTime);
        movementControl = false;
        EndDash = true;
        rb.velocity = new Vector2(0,0);
        StartCoroutine(TimerCD());
    }

    IEnumerator TimerCD()
    {       
        yield return new WaitForSeconds(DashCD);
        EndDash = false;
    }

    protected override void Death()
    {
        Destroy(gameObject);
    }
}
