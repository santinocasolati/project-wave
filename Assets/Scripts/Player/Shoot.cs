using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private bool shooting;
    private float currentTimer;
    public float shootDelay;
    [SerializeField] private GameObject bulletPrefab;

    private void CheckInputs()
    {
        float shootInput = Input.GetAxis("Shoot");

        if (shootInput > 0 && !shooting)
        {
            Fire();
        }
    }

    private void Fire()
    {
        shooting = true;
        currentTimer = 0f;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletFly>().SetDirection(transform.right);
    }

    private void DelayHandler()
    {
        if (shooting)
        {
            currentTimer += Time.deltaTime;

            if (currentTimer >= shootDelay)
            {
                shooting = false;
            }
        }
    }

    private void Update()
    {
        CheckInputs();
        DelayHandler();
    }
}
