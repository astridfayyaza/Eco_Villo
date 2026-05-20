using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] props;

    public int amount = 20;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    void Start()
    {
        SpawnProps();
    }

    void SpawnProps()
    {
        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, props.Length);

            Vector2 randomPosition = new Vector2(
                Random.Range(minPosition.x, maxPosition.x),
                Random.Range(minPosition.y, maxPosition.y)
            );

            Instantiate(
                props[randomIndex],
                randomPosition,
                Quaternion.identity
            );
        }
    }
}