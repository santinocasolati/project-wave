using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public float speed = 10f;

    public float flyDistance;
    private Vector3 moveDirection;

    private Vector3 initialPos;
    [SerializeField] private int bulletDamage;

    private void HandleDistance()
    {
        if (Vector3.Distance(initialPos, transform.position) > flyDistance)
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
        Destroy(gameObject);

        if (hit != null)
        {
            hit.ApplyDamage(bulletDamage);
        }
    }

    private void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        HandleDistance();
    }

    private void Start()
    {
        initialPos = transform.position;
    }
}
