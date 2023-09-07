using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 movement;
    private float inputMagnitude;

    [SerializeField] private float rotationSpeed;

    private void CheckInputs()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        inputMagnitude = Mathf.Clamp01(movement.magnitude);
        movement.Normalize();
    }

    private void Move()
    {
        transform.Translate(movement * moveSpeed * inputMagnitude * Time.deltaTime, Space.World);

        if (movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        CheckInputs();
        Move();
    }
}
