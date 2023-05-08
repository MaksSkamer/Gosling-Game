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
    private float cooldown = 0.5f;
    private float lastswing;

    protected AudioSource a;
    public AudioClip[] sound;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        a = GetComponent<AudioSource>();
        a.volume = 0.5f;
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time - lastswing > cooldown)
            {
                lastswing = Time.time;
                int randS = Random.Range(0, 3);
                GameManager.instance.Sound(a, sound, randS);
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D col)
    {
        if (col.tag == "Fighter" || col.tag == "Boss")
        {
            if (col.name == "Player")
                return;

            if(col.tag == "Boss")
            {
                Damage dmgB = new Damage
                {
                    damageAmount = damagePoint,
                    origin = transform.position,
                    pushForce = 0,
                };
                col.SendMessage("ReceiveDamage", dmgB);
            }
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
        // Изменение урона в %%
    }
}
