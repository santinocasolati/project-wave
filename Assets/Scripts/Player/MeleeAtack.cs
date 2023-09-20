using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtack : MonoBehaviour
{
    public float coolDown;

    private float currentCoolDown;
    private bool canAttack = true;

    private float animTime = 0.717f;

    private Animator anim;
    private Shoot shoot;
    private Transform weaponSlot;

    private void CheckInput()
    {
        if (Input.GetButtonDown("Melee"))
        {
            Attack();
        }

        if (!canAttack)
        {
            currentCoolDown += Time.deltaTime;

            if (currentCoolDown >= animTime)
            {
                anim.SetBool("isMelee", false);
                weaponSlot.GetChild(0).gameObject.SetActive(true);
                shoot.canShoot = true;
            }

            if (currentCoolDown >= coolDown)
            {
                canAttack = true;
                currentCoolDown = 0f;
            }
        }
    }

    private void Attack()
    {
        if (canAttack)
        {
            weaponSlot.GetChild(0).gameObject.SetActive(false);
            anim.SetBool("isMelee", true);
            canAttack = false;
            shoot.canShoot = false;
        }
    }

    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        weaponSlot = transform.Find("WeaponSlot");
        shoot = transform.gameObject.GetComponent<Shoot>();
    }

    void Update()
    {
        CheckInput();
    }
}
