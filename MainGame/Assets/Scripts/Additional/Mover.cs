using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected Vector3 moveVector;    
    protected RaycastHit2D hit;
    

    public float Yspeed = 20f;
    public float Xspeed = 20f;   

    protected virtual void UpdateMotor(Vector3 input)
    {
        // �������������� ������� ��������
        moveVector = new Vector3(input.x * Xspeed, input.y * Yspeed, 0);      

        // ��������� ������� � ����������� �� �������� ����� ��� ������
        if (moveVector.x < 0)
            transform.localScale = Vector3.one;
        else if (moveVector.x > 0)
            transform.localScale = new Vector3(-1,1,1);

        // �������� ������ ������������
        moveVector += pushDirection;
        // ���������� ���� ������������ ������ ����, ����������� �� �������� �������������� �� �����
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushReoverySpeed);

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
 
}
