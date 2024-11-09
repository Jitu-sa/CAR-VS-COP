using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject spritePrefab; // Reference to the sprite prefab
    public Vector2 spawnRangeX = new Vector2(-5f, 5f); // Range of X coordinates
    public Vector2 spawnRangeY = new Vector2(-3f, 3f); // Range of Y coordinates
    public float spawnInterval = 1f; // Time interval between spawns

    private float timeSinceLastSpawn = 0f;

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnSprite();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnSprite()
    {
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);

        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
        Instantiate(spritePrefab, spawnPosition, Quaternion.identity);
    }
}
