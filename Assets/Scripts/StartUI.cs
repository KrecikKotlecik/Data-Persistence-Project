using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public InputField nameInput;
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        SaveManager.Instance.playerName = nameInput.text;
    }

}
