using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.ParticleSystemJobs;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text NameText;
    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;
    public static int m_HighScore;
    public static string nameOfPlayerWithHighScore;

    private bool m_GameOver = false;

    public AudioClip brickHit;
    public AudioSource audioSource;

    public ParticleSystem _pfx;

    public GameObject ball;

    

    void Start()
    {
        const float step = 0.6f;

        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }


    private void Update()
    {
        if (!m_GameOver)
        {
            _pfx.transform.position = ball.transform.position;
        }

        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();
                

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (MenuManager.Instance != null)
        {
            NameText.text = "Best Score: " + nameOfPlayerWithHighScore + ": " + m_HighScore;
        }

        HighScoreUpdater();

    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
        audioSource.PlayOneShot(brickHit);

        var main = _pfx.main;
        main.startColor = new ParticleSystem.MinMaxGradient(BallColliding.newColor);


        HighScoreUpdater();
    }

    int HighScoreUpdater()
    {
        if (m_Points >= m_HighScore)
        {
            m_HighScore = m_Points;
            nameOfPlayerWithHighScore = MenuUIManager.nameOfPlayer;
            MenuManager.SaveHighScore();
        }
        return m_HighScore;
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
