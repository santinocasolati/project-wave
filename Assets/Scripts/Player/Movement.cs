using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 movement;

    private void CheckInputs()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        if (movement != Vector2.zero)
        {
            transform.Translate(movement.normalized.x * moveSpeed * Time.deltaTime, movement.normalized.y * moveSpeed * Time.deltaTime, 0);
        }
    }

    private void Update()
    {
        CheckInputs();
        Move();
    }
}
