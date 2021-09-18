using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUI : MonoBehaviour
{
    public InputField playerNameInput;
    public Text highScoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        ShowHighscore();
    }

    public void StartGame()
    {

        SceneManager.LoadScene(1);
    }

    public void ShowLeaderboard()
    {
        SceneManager.LoadScene(2);
    }

    public void ShowSettings()
    {
        SceneManager.LoadScene(3);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void AssignPlayerName()
    {
        GameManager.Instance.newName = playerNameInput.text;
        //Call save PlayerName function
    }

    public void ShowHighscore()
    {
        highScoreText.text = "Highscore: " + GameManager.Instance.highScoreName[0] + ", " + GameManager.Instance.highScore[0];
    }
}
