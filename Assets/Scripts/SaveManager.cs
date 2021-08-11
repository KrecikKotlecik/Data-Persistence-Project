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
    public int highScore = 0;
    public string bestPlayer;

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
        mainManagerX = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    private void Update()
    {
        if(currentScore > highScore)
        {
            highScore = currentScore;
            bestPlayer = playerName;
        }
    }

    [System.Serializable]
    class SaveHighScore
    {
        public string name;
        public int highScore;
    }

    public void SaveScore()
    {
        SaveHighScore data = new SaveHighScore();
        data.name = bestPlayer;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveHighScore data = JsonUtility.FromJson<SaveHighScore>(json);

            highScore = data.highScore;
            bestPlayer = data.name;
        }
    }
}
