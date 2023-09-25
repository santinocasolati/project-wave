using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnDelay = 1f;
    public int maxAmount = 1;

    private float currentTime;
    private int currentAmount;

    [SerializeField] private TilemapCollider2D walls;
    private TilemapCollider2D col;
    private Bounds bounds;

    void Start()
    {
        col = GetComponent<TilemapCollider2D>();
        bounds = col.bounds;
    }

    private Vector3 GeneratePoint()
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
            );
    }

    private void SpawnEnemy()
    {
        Vector3 point = GeneratePoint();

        if (!walls.OverlapPoint(point))
        {
            GameObject instance = Instantiate(enemy, transform.position, Quaternion.identity);
            instance.GetComponent<AIDestinationSetter>().target = GameObject.Find("Player").transform;
            currentTime = 0f;
            currentAmount++;
        }
    }

    void Update()
    {
        if (currentAmount < maxAmount)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= spawnDelay)
            {
                SpawnEnemy();
            }
        }
    }
}
