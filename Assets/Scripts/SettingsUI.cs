using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider paddleSpeedSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = GameManager.Instance.volume;
        paddleSpeedSlider.value = GameManager.Instance.paddleSpeed;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeVolume()
    {
        GameManager.Instance.ChangeMusicVolume(volumeSlider.value);
    }

    public void ChangePaddleSpeed()
    {
        GameManager.Instance.ChangePaddleSpeed(paddleSpeedSlider.value);
    }
}
