using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{

    public TMP_InputField playerNameInput;

    public void StartGame()
    {
        if (playerNameInput.text != "")
        {
            GameData.Instance.NewPlayerName = playerNameInput.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogWarning("Please, write your name before starting the game!");
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
