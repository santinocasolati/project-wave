using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class PathfinderManager : MonoBehaviour
{
    private Transform player;
    public float chaseDistance;
    public float stopDistance;

    private AIDestinationSetter targetSetter;
    private AIPath pathHelper;
    private bool inRange = false;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        targetSetter = gameObject.GetComponent<AIDestinationSetter>();
        pathHelper = gameObject.GetComponent<AIPath>();
        pathHelper.endReachedDistance = stopDistance;
        pathHelper.slowdownDistance = stopDistance + 0.5f;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= chaseDistance)
        {
            targetSetter.target = player;
        } else
        {
            targetSetter.target = null;
        }
    }
}
