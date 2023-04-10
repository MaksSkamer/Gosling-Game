using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    // Открытые поля для установки первоначального ХП и макс. ХП
    public int hitpoint = 50;
    public int maxHitpoint = 100;
    public float pushReoverySpeed = 0.2f;

    // Время бессмертия после удара
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Толчок
    protected Vector3 pushDirection;

    protected BoxCollider2D boxColider;

    protected virtual void Start()
    {
        boxColider = GetComponent<BoxCollider2D>();
    }
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            
            // Визуальные эффекты
            if(transform.name == "Player")
                GameManager.instance.ShowText("- " + dmg.damageAmount.ToString() + " HP", 50, Color.red, transform.position + new Vector3(3,5,0), Vector3.up * 30, 0.5f);
            else
                GameManager.instance.ShowText("- " + dmg.damageAmount.ToString() + " HP", 50, Color.red, transform.position + new Vector3(8, 0, 0), Vector3.up * 30, 0.5f);

            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {

    }
}
