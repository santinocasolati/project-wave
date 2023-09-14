using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtack : MonoBehaviour
{
    public float coolDown;

    private float currentCoolDown;
    private bool canAttack = true;

    Animator anim;

    private void CheckInput()
    {
        if (Input.GetButtonDown("Melee"))
        {
            Attack();
        }

        if (!canAttack)
        {
            currentCoolDown += Time.deltaTime;

            if (currentCoolDown >= coolDown)
            {
                canAttack = true;
                anim.SetBool("isMelee", false);
                currentCoolDown = 0f;
            }
        }
    }

    private void Attack()
    {
        if (canAttack)
        {
            anim.SetBool("isMelee", true);
            canAttack = false;
        }
    }

    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        CheckInput();
    }
}
