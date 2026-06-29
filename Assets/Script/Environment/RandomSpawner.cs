using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour
{
    [Header("Trash Prefabs")]
    public GameObject[] props;

    [Header("Spawn Settings")]
    public int amount = 20;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    [Header("Obstacle Check")]
    public LayerMask obstacleLayer;

    public float checkRadius = 0.3f;

    public int maxAttempts = 50;


    IEnumerator Start()
    {
        yield return null;

        SpawnProps();
    }

    void SpawnProps()
    {
        int spawnedCount = 0;
        int attempts = 0;

        while (spawnedCount < amount &&
               attempts < amount * maxAttempts)
        {
            attempts++;

            Vector2 randomPosition =
                new Vector2(
                    Random.Range(
                        minPosition.x,
                        maxPosition.x
                    ),
                    Random.Range(
                        minPosition.y,
                        maxPosition.y
                    )
                );

            Collider2D hit =
                Physics2D.OverlapCircle(
                    randomPosition,
                    checkRadius,
                    obstacleLayer
                );

            bool blocked = hit != null;

            if (!blocked)
            {
                int randomIndex =
                    Random.Range(
                        0,
                        props.Length
                    );

                Instantiate(
                    props[randomIndex],
                    randomPosition,
                    Quaternion.identity
                );

                spawnedCount++;

                if (TrashManager.Instance != null)
                {
                    TrashManager.Instance.RegisterTrash();
                }
            }
        }

        Debug.Log(
            "Spawned Trash: " +
            spawnedCount +
            "/" +
            amount
        );
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Vector2 center =
            (minPosition + maxPosition) / 2;

        Vector2 size =
            maxPosition - minPosition;

        Gizmos.DrawWireCube(
            center,
            size
        );
    }
}