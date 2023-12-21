using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f; // Geschwindigkeit des Gegners

    void Update()
    {
        // Bewegung des Gegners auf der X-Achse
        MoveOnXAxis();
    }

    void MoveOnXAxis()
    {
        // Aktuelle Position des Gegners
        Vector3 currentPosition = transform.position;

        // Neue X-Position basierend auf der Geschwindigkeit und der Zeit seit dem letzten Frame
        float newXPosition = currentPosition.x + speed * Time.deltaTime;

        // Setzen der neuen Position
        transform.position = new Vector3(newXPosition, currentPosition.y, currentPosition.z);
    }
}