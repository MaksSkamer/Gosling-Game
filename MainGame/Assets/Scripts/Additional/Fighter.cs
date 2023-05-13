using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Fighter : MonoBehaviour
{
    // Открытые поля для установки первоначального ХП и макс. ХП
    public int hitpoint = 50;
    public int maxHitpoint = 100;
    public float pushReoverySpeed = 0.2f;
    protected float lastHit;

    // Время бессмертия после удара
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Толчок
    protected Vector3 pushDirection;
    Color tmp;
    protected BoxCollider2D boxColider;
    protected SpriteRenderer sprite;

    protected virtual void Start()
    {     
        sprite = GetComponent<SpriteRenderer>();
        boxColider = GetComponent<BoxCollider2D>();
        tmp = sprite.GetComponent<SpriteRenderer>().color;
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
            {
                if(Time.time - lastHit > pushReoverySpeed)
                {
                    lastHit = Time.time;
                    StartCoroutine(Blinker());
                }
                GameManager.instance.ShowText("- " + dmg.damageAmount.ToString() + " HP", 40, new Color(0.796f, 0.2f, 0.2f), transform.position + new Vector3(3, 5, 0), Vector3.up * 30, 0.5f);
            }                  
            else
                GameManager.instance.ShowText("- " + dmg.damageAmount.ToString() + " HP", 30, Color.red, transform.position + new Vector3(8, 0, 0), Vector3.up * 30, 0.5f);

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

    IEnumerator Blinker()
    {
        Color tmp = sprite.color;
        sprite.color = tmp;

        tmp.a = 0;
        yield return new WaitForSeconds(0f);
        sprite.color = tmp;
        tmp.a = 255;

        yield return new WaitForSeconds(0.05f);
        sprite.color = tmp;
        tmp.a = 0;

        yield return new WaitForSeconds(0.05f);
        sprite.color = tmp;
        tmp.a = 255f;

        yield return new WaitForSeconds(0.05f);
        sprite.color = tmp;
        tmp.a = 0;

        yield return new WaitForSeconds(0.05f);
        sprite.color = tmp;
        tmp.a = 255f;

        yield return new WaitForSeconds(0.05f);
        sprite.color = tmp;
        tmp.a = 0;

        yield return new WaitForSeconds(0.05f);
        sprite.color = tmp;
        tmp.a = 255f;

        yield return new WaitForSeconds(0.05f);
        sprite.color = tmp;
        tmp.a = 0;

        yield return new WaitForSeconds(0.05f);
        sprite.color = tmp;
        tmp.a = 255f;

        yield return new WaitForSeconds(0.05f);
        sprite.color = tmp;
        tmp.a = 0;

        StopCoroutine("Blinker");
    }

}
