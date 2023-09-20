using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloor : MonoBehaviour
{
    public Transform target;
    public bool canTeleport = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTeleport)
        {
            ChangeFloor tc = target.gameObject.GetComponent<ChangeFloor>();

            if (tc != null)
            {
                tc.canTeleport = false;
            }

            HealthHandler hh = collision.gameObject.GetComponent<HealthHandler>();

            if (hh != null)
            {
                hh.gameObject.transform.position = target.position;
                Camera.main.GetComponent<CameraFollow>().FastUpdate();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HealthHandler hh = collision.gameObject.GetComponent<HealthHandler>();

        if (hh != null)
        {
            canTeleport = true;
        }
    }
}
