using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int newScore;
    public int oldScore;
    public int highScore;

    public string newName;
    public string highScoreName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadStuff();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerNameSaved;
        public int highscoreSaved;
    }

    public void SaveStuff()
    {
        Debug.Log(newScore + ", " + highScore);
        CheckHighscore(newScore, highScore);

        SaveData data = new SaveData();
        data.playerNameSaved = highScoreName;
        data.highscoreSaved = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadStuff()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScoreName = data.playerNameSaved;
            highScore = data.highscoreSaved;
        }
    }

    public void CheckHighscore(int score1, int score2)
    {
        if (score1 <= score2)
        {
            highScore = score2;
        }
        else
        {
            highScore = score1;
            highScoreName = newName;
        }
    }
}
