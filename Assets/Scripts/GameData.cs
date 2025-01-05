using System;
using System.IO;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    public string NewPlayerName { get; set; }
    public ScoreSaveData ScoreData { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            InitializeGameData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeGameData()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    public void SaveScore()
    {
        string path = Application.persistentDataPath + "/savefile_datapersistance.json";
        File.WriteAllText(path, JsonUtility.ToJson(ScoreData));
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile_datapersistance.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreData = JsonUtility.FromJson<ScoreSaveData>(json);
        }
        else
        {
            ScoreData = new ScoreSaveData();
            Debug.LogWarning("No data was found saved");
        }
    }

    [Serializable]
    public class ScoreSaveData
    {
        public string playerName;
        public int highScore;
    }
}
