using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject obstaclePrefab;
    public GameObject coinPrefab;
    public Transform player;
    public Transform obstacleSpawnPoint;
    public Transform coinSpawnPoint;
    public float obstacleSpeed = 5f;
    public float coinSpawnInterval = 5f;
    public int score = 0;
    public Text scoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2f, 2f);
        InvokeRepeating("SpawnCoin", coinSpawnInterval, coinSpawnInterval);
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, obstacleSpawnPoint.position, Quaternion.identity);
    }

    void SpawnCoin()
    {
        Instantiate(coinPrefab, coinSpawnPoint.position, Quaternion.identity);
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreText(); // Appel à la fonction pour mettre à jour le texte
    }

    void UpdateScoreText()
    {
        // Mettez à jour le texte avec le score actuel
        if (scoreText != null)
        {
            scoreText.text = "Coins: " + score.ToString();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("SceneMenu");
    }
}
