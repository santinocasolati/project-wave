using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootDelay = 1f;

    private Animator anim;
    private float currentTime = 0f;
    public bool shooted = false;

    private void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    public void Shoot(Vector3 direction)
    {
        Transform shootPos = transform.Find("ShootPosition");

        GameObject bullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        bullet.GetComponent<BulletFly>().SetDirection(direction);

        anim.SetBool("Shoot", true);
        shooted = true;
    }

    private void Update()
    {
        if (shooted)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= shootDelay)
            {
                anim.SetBool("Shoot", false);
                shooted = false;
                currentTime = 0f;
            }
        }
    }
}
