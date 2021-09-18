using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int newScore;
    public int oldScore;
    public int[] highScore;

    public string newName;
    public string[] highScoreName;

    public float volume;
    public float paddleSpeed;

    private AudioSource music;

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

    private void Start()
    {
        music = GetComponent<AudioSource>();
        music.volume = volume;
    }

    [System.Serializable]
    class SaveData
    {
        public string[] playerNameSaved;
        public int[] highscoreSaved;
        public float volumeSaved;
        public float paddleSpeedSaved;
    }

    public void SaveStuff()
    {
        CheckHighscore(newScore);

        SaveData data = new SaveData();
        data.playerNameSaved = highScoreName;
        data.highscoreSaved = highScore;
        data.volumeSaved = volume;
        data.paddleSpeedSaved = paddleSpeed;

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
            volume = data.volumeSaved;
            paddleSpeed = data.paddleSpeedSaved;
        }
    }

    public void CheckHighscore(int score1)
    {
        for (int i = 0; i < highScore.Length; i++)
        {
            if (score1 > highScore[i])
            {
                for (int j = highScore.Length - 1; j >= i + 1; j--)
                {
                    highScore[j] = highScore[j - 1];
                    highScoreName[j] = highScoreName[j - 1];
                }

                highScore[i] = score1;
                highScoreName[i] = newName;

                return;
            }
        }
    }

    public void ChangeMusicVolume(float vol)
    {
        music.volume = vol;
        volume = vol;
    }

    public void ChangePaddleSpeed(float speed)
    {
        paddleSpeed = speed;
    }
}