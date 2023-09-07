using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public float speed = 10f;

    private float currentTime;
    public float flyTime;
    private Vector3 moveDirection;

    [SerializeField] private int bulletDamage;

    private void HandleTimer()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= flyTime)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthHandler hit = collision.GetComponent<HealthHandler>();

        if (hit != null)
        {
            hit.ApplyDamage(bulletDamage);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        HandleTimer();
    }
}
