using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float moveSpeed;
    public float minDistance;
    public float maxDistance;

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= maxDistance)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion target = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Lerp(transform.rotation, target, 5 * Time.deltaTime);

            if (Vector3.Distance(transform.position, player.position) >= minDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }
    }
}
