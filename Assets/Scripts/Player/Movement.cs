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
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    private void Update()
    {
        CheckInputs();
        Move();
    }
}
