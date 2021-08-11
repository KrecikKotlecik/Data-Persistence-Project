using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    private int newScore;
    private string newPlayer;

    public Text leader1;
    public Text leader2;
    public Text leader3;
    public Text leader4;
    public Text leader5;

    int highScore1;
    string bestPlayer1;
    int highScore2;
    string bestPlayer2;
    int highScore3;
    string bestPlayer3;
    int highScore4;
    string bestPlayer4;
    int highScore5;
    string bestPlayer5;

    private void Update()
    {
        UpdateLeaderboard();

        leader1.text = $"1. {bestPlayer1}: {highScore1}";
        leader2.text = $"2. {bestPlayer2}: {highScore2}";
        leader3.text = $"3. {bestPlayer3}: {highScore3}";
        leader4.text = $"4. {bestPlayer4}: {highScore4}";
        leader5.text = $"5. {bestPlayer5}: {highScore5}";
    }
    public void UpdateLeaderboard()
    {
        highScore1 = SaveManager.Instance.highScore1;
        bestPlayer1 = SaveManager.Instance.bestPlayer1;
        highScore2 = SaveManager.Instance.highScore2;
        bestPlayer2 = SaveManager.Instance.bestPlayer2;
        highScore3 = SaveManager.Instance.highScore3;
        bestPlayer3 = SaveManager.Instance.bestPlayer3;
        highScore4 = SaveManager.Instance.highScore4;
        bestPlayer4 = SaveManager.Instance.bestPlayer4;
        highScore5 = SaveManager.Instance.highScore5;
        bestPlayer5 = SaveManager.Instance.bestPlayer5;
    }
}
