using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public string playerName;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    public int highScore = 0;
    bool newHighScore = false;
    public string bestPlayer;
    public Text bestScoreText;
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        bestPlayer = SaveManager.Instance.bestPlayer;
        highScore = SaveManager.Instance.highScore;
        bestScoreText.text = $"Best Score: {bestPlayer}: {highScore}";
        playerName = SaveManager.Instance.playerName;
        ScoreText.text = $"{playerName}'s Score : 0";

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
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
        bestScoreText.text = $"Best Score: {bestPlayer}: {highScore}";
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"{playerName}'s Score : {m_Points}";
        if(m_Points > highScore)
        {
            highScore = m_Points;
            bestPlayer = playerName;
            newHighScore = true;
        }
    }

    public void GameOver()
    {
        SaveManager.Instance.currentScore = m_Points;
        SaveManager.Instance.playerName = playerName;
        SaveManager.Instance.SaveScore();

        m_GameOver = true;
        GameOverText.SetActive(true);


    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

}
