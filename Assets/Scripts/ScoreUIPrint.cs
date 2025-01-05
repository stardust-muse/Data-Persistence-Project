using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class ScoreUIPrint : MonoBehaviour
{
    private Text highScoreText;

    private void Start()
    {
        highScoreText = GetComponent<Text>();
        PrintHighScore();
    }
    public void PrintHighScore()
    {
        string name = GameData.Instance.ScoreData.playerName;
        int score = GameData.Instance.ScoreData.highScore;
        if (score > 0)
        {
            highScoreText.text = $"Best Score: {name} : {score}";
        }
        else
        {
            highScoreText.text = "No Best Score Yet!";
        }
    }
}
