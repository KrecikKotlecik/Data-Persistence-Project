using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private int newScore;
    private string newPlayer;

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

    public void UpdateLeaderboard()
    {
        if(newScore < highScore1)
        {
            highScore1 = newScore;
            bestPlayer1 = newPlayer;
        }
        else if(newScore < highScore2)
        {
            highScore2 = newScore;
            bestPlayer2 = newPlayer;
        }
        else if(newScore < highScore3)
        {
            highScore3 = newScore;
            bestPlayer3 = newPlayer;
        }
        else if(newScore < highScore4)
        {
            highScore4 = newScore;
            bestPlayer4 = newPlayer;
        }
        else if(newScore < highScore5)
        {
            highScore5 = newScore;
            bestPlayer5 = newPlayer;
        }
        else
        {
            return;
        }
    }
}
