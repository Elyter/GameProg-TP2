using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float obstacleSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * (obstacleSpeed + Random.Range(0f, 10f))  * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.EndGame();
        }
    }
}
