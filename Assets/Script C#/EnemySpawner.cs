using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Das Prefab des Enemies
    public float spawnInterval = 2f; // Das Spawn-Intervall in Sekunden
    public float minY = -3f; // Minimaler Y-Wert
    public float maxY = 3f; // Maximaler Y-Wert

    private float timer;

    void Update()
    {
        // Aktualisiere den Timer
        timer += Time.deltaTime;

        // Überprüfe, ob das Spawn-Intervall erreicht wurde
        if (timer >= spawnInterval)
        {
            // Spawne den Enemy
            SpawnEnemy();

            // Setze den Timer zurück
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Berechne eine zufällige Position auf der Y-Achse
        float randomY = Random.Range(minY, maxY);

        // Erzeuge die Position für den Spawner
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);

        // Spawne den Enemy an der berechneten Position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}