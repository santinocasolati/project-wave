using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float shootInput;
    private bool shooting;
    private float currentTimer;
    public float shootDelay;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform sprite;

    private void CheckInputs()
    {
        shootInput = Input.GetAxis("Shoot");

        if (shootInput > 0 && !shooting)
        {
            Fire();
        }
    }

    private void Fire()
    {
        // TODO add shoot point to the weapon
        shooting = true;
        currentTimer = 0f;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - transform.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletFly>().SetDirection(direction);
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
