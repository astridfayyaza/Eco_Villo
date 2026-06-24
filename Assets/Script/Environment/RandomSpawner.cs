using UnityEngine;

[System.Serializable]
public class TrashData
{
    public GameObject prefab;

    [Range(0, 100)]
    public int percentage;
}


public class RandomSpawner : MonoBehaviour
{
    public TrashData[] props;

    public int amount = 20;


    public Vector2 minPosition;
    public Vector2 maxPosition;


    void Start()
    {
        SpawnProps();
    }


    void SpawnProps()
    {
        foreach (TrashData trash in props)
        {
            int spawnAmount =
                Mathf.RoundToInt(
                    amount * (trash.percentage / 100f)
                );


            for (int i = 0; i < spawnAmount; i++)
            {
                SpawnObject(trash.prefab);
            }
        }
    }


    void SpawnObject(GameObject prefab)
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y)
        );

        GameObject trash = Instantiate(prefab, randomPosition, Quaternion.identity);

        TrashManager.Instance.RegisterTrash();
    }
}