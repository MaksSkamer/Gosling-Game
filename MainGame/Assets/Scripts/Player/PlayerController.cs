using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Mover
{

    public float DashImpulse = 4000;
    private float DashTime = 0.09f;
    private float DashCD = 1f;
    private bool EndDash;
    private bool movementControl;
    private float x;
    private float y;
    private float MaxCdDash = 1f;
    private float CdDash = 1f;
    private Rigidbody2D rb;
    GameObject DeathMenu;
    public Image DashUIBar;


    protected override void Start()
    {               
        
        DeathMenu = GameObject.FindWithTag("DM");
        DeathMenu.SetActive(false);
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        EndDash = false;
        movementControl= false;       
    }
    private void FixedUpdate()
    {
        GameManager.instance.OnHitpointChange();
        DashUI();
        if (movementControl == false)
        {
            rb.velocity = new Vector2(0,0);
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");

            UpdateMotor(new Vector3(x, y, 0));


        }
        else {  }      
        Dash();
    }
    public void DashUI()
    {
        if (CdDash < MaxCdDash)
        {
            CdDash += Time.deltaTime;
            float scale = CdDash / MaxCdDash;
            DashUIBar.fillAmount = scale;
        }
    }

    private void Dash()
    {
        if (x < 0 && y > 0 && Input.GetKey(KeyCode.LeftShift) && EndDash == false)
        {
            CDDash();
            StartCoroutine(Timer());
            if (EndDash == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, DashImpulse);
                rb.velocity = new Vector2(-DashImpulse, rb.velocity.y);
            }
        }
        if (x < 0 && y < 0 && Input.GetKey(KeyCode.LeftShift) && EndDash == false)
        {
            CDDash();
            StartCoroutine(Timer());
            if (EndDash == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, -DashImpulse);
                rb.velocity = new Vector2(-DashImpulse, rb.velocity.y);
            }
        }
        if (x > 0 && y > 0 && Input.GetKey(KeyCode.LeftShift) && EndDash == false)
        {
            CDDash();
            StartCoroutine(Timer());
            if (EndDash == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, DashImpulse);
                rb.velocity = new Vector2(DashImpulse, rb.velocity.y);
            }
        }
        if (x > 0 && y < 0 && Input.GetKey(KeyCode.LeftShift) && EndDash == false)
        {
            CDDash();
            StartCoroutine(Timer());
            if (EndDash == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, -DashImpulse);
                rb.velocity = new Vector2(DashImpulse, rb.velocity.y);
            }
        }
        else if (x < 0 && Input.GetKey(KeyCode.LeftShift) && EndDash == false)
        {
            CDDash();
            StartCoroutine(Timer());
            if (EndDash == false)
            {               
                rb.velocity = new Vector2(-DashImpulse, rb.velocity.y);
            }
        }        
        else if (x > 0 && Input.GetKey(KeyCode.LeftShift) && EndDash == false)
        {
            CDDash();
            StartCoroutine(Timer());
            if (EndDash == false)
            {
                rb.velocity = new Vector2(DashImpulse, rb.velocity.y);
            }
        }
        else if (y < 0 && Input.GetKey(KeyCode.LeftShift) && EndDash == false)
        {
            CDDash();
            StartCoroutine(Timer());
            if (EndDash == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, -DashImpulse);
            }
        }
        else if (y > 0 && Input.GetKey(KeyCode.LeftShift) && EndDash == false)
        {
            CDDash();
            StartCoroutine(Timer());
            if (EndDash == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, DashImpulse);
            }
        }
    }
    private void CDDash()
    {
        CdDash = 0;
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
        GameManager.instance.DeathSc = true;
        GameObject pl = GameObject.Find("Player");
        pl.SetActive(false);
        DeathMenu.SetActive(true);
        Time.timeScale = 0f;
        GameManager.instance.RenamePL();
        Debug.Log(GameManager.instance.plName);
    }

}
