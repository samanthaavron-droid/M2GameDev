using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class MosqManager : MonoBehaviour
{
    public Vector2 topright;
    public Vector2 bottomleft;

    public Rzaba Player;
    public GameObject Mosqitoe;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScreen;
    public TextMeshProUGUI waveScreen;

    public static MosqManager instance;

    private bool gameOver;
    private int currentWave;
    private int currentScore;
    private int killCount;

    public Transform point1;
    public Transform point2;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        currentScore = 0;
        int totalScore = PlayerPrefs.GetInt("totalScore");
        scoreText.text = "This hunt: " + currentScore.ToString() + " victims \n" + "Captured: " + totalScore.ToString() + " mosquitoes";

        currentWave = 1;
        killCount = -2;
        gameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R) && gameOver == true)
        {
            SceneManager.LoadScene("Swamp");
            gameOver = false;
            Time.timeScale = 1;
        }

        if (killCount == currentWave * 2)
        {
            currentWave += 1;
            killCount = 0;

            StartCoroutine(Spawner());
            waveScreen.gameObject.SetActive(true);
        }
    }

    public IEnumerator Spawner()
    {
        yield return new WaitForSeconds(5f);
        waveScreen.gameObject.SetActive(false);

        for (int i = 0; i < currentWave * 2; i++)
        {
            if (Mosqitoe == null)
                Debug.LogError("Mosqitoe prefab not selected");
            else
            {
                GameObject newMosq = Instantiate(Mosqitoe, GetRandomSpawnPosition(), Quaternion.identity);
                Debug.Log("Respawn successful");
            }
        }
    }
    public void MosqMan()
    {
        AddPoints(+1);
        killCount++;

        //the first tutorial kill
        if (killCount == -1)
        {
            killCount = 0;
            currentWave = 1;

            StartCoroutine(Spawner());
            waveScreen.gameObject.SetActive(true);
        }
    }

    private Vector2 GetRandomSpawnPosition()
    {
        const float checkRadius = 0.5f;
        const int maxAttempts = 5;

        for (int i = 0; i < maxAttempts; i++)
        {
            float x = UnityEngine.Random.Range(point1.position.x, point2.position.x);
            float y = UnityEngine.Random.Range(point1.position.y, point2.position.y);
            Vector2 spawnPosition = new Vector2(x, y);

            bool isOverlapping = Physics2D.OverlapCircle(spawnPosition, checkRadius);
            if (!isOverlapping)
            {
                Debug.Log("Spawned at: " + spawnPosition);
                return spawnPosition;
            }
        }
        Debug.LogWarning("Could not find a non-overlapping position. Spawning at 0");
        return Vector2.zero;
    }

    public void AddPoints(int points)
    {
        currentScore += points;

        int totalScore = PlayerPrefs.GetInt("totalScore");
        totalScore += points;

        scoreText.text = "This hunt: " + currentScore.ToString() + " victims \n" + "Captured: " + totalScore.ToString() + " mosquitoes";

        PlayerPrefs.SetInt("totalScore", totalScore);
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver = true;
        gameOverScreen.gameObject.SetActive(true);
    }

}