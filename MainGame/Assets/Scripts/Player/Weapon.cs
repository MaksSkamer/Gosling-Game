using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    // Апгрейд
    public int weaponlvl = 0;
    private SpriteRenderer spriteRenderer;

    // Взмах
    private Animator anim;
    private float cooldown = 1.5f;
    private float lastswing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time - lastswing > cooldown)
            {
                lastswing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D col)
    {
        if (col.tag == "Fighter" || col.tag == "Enemy")
        {
            if (col.name == "Player")
                return;

            // Создать новый наносящий урон объект, а затем отправить его в того кого бьём
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce,
            };
            col.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void Swing()
    {
        anim.SetTrigger("Swing");
    }

    public void UpgradeWeapon()
    {
        weaponlvl++;
        // »зменение урона в %%
    }
}
