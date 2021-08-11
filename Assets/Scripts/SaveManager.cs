using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private MainManager mainManagerX;

    public int currentScore;
    public string playerName;
    public int highScore1;
    public string bestPlayer1;
    public int highScore2;
    public string bestPlayer2;
    public int highScore3;
    public string bestPlayer3;
    public int highScore4;
    public string bestPlayer4;
    public int highScore5;
    public string bestPlayer5;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);

            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    private void Start()
    {
    }

    [System.Serializable]
    class ScoreLeaderboard
    {
        public string name1;
        public int score1;
        public string name2;
        public int score2;
        public string name3;
        public int score3;
        public string name4;
        public int score4;
        public string name5;
        public int score5;
    }

    public void SaveScore()
    {
        ScoreLeaderboard data = new ScoreLeaderboard();
        data.name1 = bestPlayer1;
        data.score1 = highScore1;
        data.name2 = bestPlayer2;
        data.score2 = highScore2;
        data.name3 = bestPlayer3;
        data.score3 = highScore3;
        data.name4 = bestPlayer4;
        data.score4 = highScore4;
        data.name5 = bestPlayer5;
        data.score5 = highScore5;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreLeaderboard data = JsonUtility.FromJson<ScoreLeaderboard>(json);

            highScore1 = data.score1;
            bestPlayer1 = data.name1;
            highScore2 = data.score2;
            bestPlayer2 = data.name2;
            highScore3 = data.score3;
            bestPlayer3 = data.name3;
            highScore4 = data.score4;
            bestPlayer4 = data.name4;
            highScore5 = data.score5;
            bestPlayer5 = data.name5;
        }
    }

    public void UpdateScore()
    {
        if (currentScore > highScore1)
        {
            highScore5 = highScore4;
            bestPlayer5 = bestPlayer4;
            highScore4 = highScore3;
            bestPlayer4 = bestPlayer3;
            highScore3 = highScore2;
            bestPlayer3 = bestPlayer2;
            highScore2 = highScore1;
            bestPlayer2 = bestPlayer1;

            highScore1 = currentScore;
            bestPlayer1 = playerName;
        }
        else if (currentScore > highScore2 && currentScore < highScore1)
        {
            highScore5 = highScore4;
            bestPlayer5 = bestPlayer4;
            highScore4 = highScore3;
            bestPlayer4 = bestPlayer3;
            highScore3 = highScore2;
            bestPlayer3 = bestPlayer2;

            highScore2 = currentScore;
            bestPlayer2 = playerName;
        }
        else if (currentScore > highScore3 && currentScore < highScore2)
        {
            highScore5 = highScore4;
            bestPlayer5 = bestPlayer4;
            highScore4 = highScore3;
            bestPlayer4 = bestPlayer3;

            highScore3 = currentScore;
            bestPlayer3 = playerName;
        }
        else if (currentScore > highScore4 && currentScore < highScore3)
        {
            highScore5 = highScore4;
            bestPlayer5 = bestPlayer4;

            highScore4 = currentScore;
            bestPlayer4 = playerName;
        }
        else if (currentScore > highScore5 && currentScore < highScore4)
        {
            highScore5 = currentScore;
            bestPlayer5 = playerName;
        }
    }
}
