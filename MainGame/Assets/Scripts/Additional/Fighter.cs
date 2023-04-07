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
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            // Визуальные эффекты
            // GameManager.instance.ShowText("- " + dmg.damageAmount.ToString() + " HP", 25, Color.red, transform.position + new Vector3(0, 5, 0), Vector3.zero, 0.5f);

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
