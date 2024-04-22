using UnityEngine;

public class CoinController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.left * GameManager.instance.obstacleSpeed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.IncrementScore();
            Destroy(gameObject);
        }
    }
}
