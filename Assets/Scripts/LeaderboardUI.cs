using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderboardUI : MonoBehaviour
{
    public Text[] highScoreText;

    private void Start()
    {
        FillLeaderboard();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void FillLeaderboard()
    {
        for (int i = 0; i < highScoreText.Length; i++)
        {
            if(i < 5)
            {
                highScoreText[i].gameObject.SetActive(true);
                highScoreText[i].text = GameManager.Instance.highScoreName[i] + ", " + GameManager.Instance.highScore[i];
            }
        }
    }
}
