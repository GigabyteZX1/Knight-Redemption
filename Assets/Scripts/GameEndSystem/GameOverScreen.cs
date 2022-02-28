using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private AudioClip buttonSelectSound;
    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "HighScore :" + score.ToString();

    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Scenes/Lvl 1", LoadSceneMode.Single);
    }

    public void QuitButton()
    {
        SoundManager.instance.PlaySound(buttonSelectSound);
        Application.Quit();
    }
}
