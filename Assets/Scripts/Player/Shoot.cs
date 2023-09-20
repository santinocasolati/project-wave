using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool canShoot = true;

    private void CheckInputs()
    {
        float shootInput = Input.GetAxis("Shoot");

        Transform weapon = transform.Find("WeaponSlot").GetChild(0);

        if (weapon != null)
        {
            if (shootInput > 0 && !weapon.gameObject.GetComponent<WeaponShoot>().shooted && canShoot)
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        Transform weapon = transform.Find("WeaponSlot").GetChild(0);

        if (weapon != null)
        {
            weapon.gameObject.GetComponent<WeaponShoot>().Shoot(transform.right);
        }
    }

    private void Update()
    {
        CheckInputs();
    }
}
