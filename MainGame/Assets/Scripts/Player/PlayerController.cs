using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Vector3 moveVector;
    protected BoxCollider2D boxColider;
    protected RaycastHit2D hit;

    public float Yspeed = 0.6f;
    public float Xspeed = 0.6f;
    void Start()
    {
        boxColider = GetComponent<BoxCollider2D>();
        DontDestroyOnLoad(gameObject);
    }

    
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveVector = new Vector3(x * Xspeed, y * Yspeed, 0);

        if (moveVector.x < 0)
            transform.localScale = Vector3.one;
        else if (moveVector.x > 0)
            transform.localScale = new Vector3(-1,1,1);

        hit = Physics2D.BoxCast(transform.position, boxColider.size, 0, new Vector2(0, moveVector.y), Mathf.Abs(moveVector.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveVector.y * Time.deltaTime, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxColider.size, 0, new Vector2(moveVector.x, 0), Mathf.Abs(moveVector.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {            
            transform.Translate(moveVector.x * Time.deltaTime, 0, 0);
        }
    }

    //protected override void Death()
    //{
    //    Destroy(gameObject);
    //}
}
