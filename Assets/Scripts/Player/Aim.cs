using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public float rotationSpeed;
    [SerializeField] private Transform sprite;

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion target = Quaternion.Euler(new Vector3(0, 0, angle));
        sprite.rotation = Quaternion.Lerp(sprite.rotation, target, rotationSpeed * Time.deltaTime);
    }
}
