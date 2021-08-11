using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartUI : MonoBehaviour
{
    public InputField nameInput;
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        SaveManager.Instance.playerName = nameInput.text;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
