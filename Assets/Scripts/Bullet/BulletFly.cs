using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    private Vector3 moveDirection;
    public float speed = 10f;

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction;
        moveDirection.z = transform.position.z;
    }

    void Update()
    {
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
    }
}
