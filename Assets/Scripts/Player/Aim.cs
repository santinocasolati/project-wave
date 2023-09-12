using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public float rotateSpeed = 1f;

    private Vector2 mouse;

    private void CheckMouse()
    {
        mouse = Input.mousePosition;
    }

    private void Rotate()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        float distanceX = mouse.x - pos.x;
        float distanceY = mouse.y - pos.y;

        float angle = Mathf.Atan2(distanceY, distanceX) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    void Update()
    {
        CheckMouse();
        Rotate();
    }
}
