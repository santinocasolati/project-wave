using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    public int camOffset;
    public float camSpeed;

    private void Update()
    {
        Vector3 target = player.position;
        target.z = camOffset;

        transform.position = Vector3.Lerp(transform.position, target, camSpeed * Time.deltaTime);
    }
}
