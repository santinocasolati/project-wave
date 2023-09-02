using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    private Vector3 moveDirection;
    public float speed = 10f;

    private float currentTime;
    public float flyTime;

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction;
        moveDirection.z = transform.position.z;
    }

    private void HandleTimer()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= flyTime)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime);

        HandleTimer();
    }
}
