using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWon : MonoBehaviour
{
    public GameObject gameobject;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip won;
    [SerializeField] private AudioClip buttonSelectSound;
    private Rigidbody2D body;
    private int score;
    public Text pointsText;

    void Awake()
    {
        body = player.GetComponent<Rigidbody2D>();
    }

    // void OnTriggerEnter2D(Collider2D other)
    // { 
    
    //     if(other.tag == "Player")
    //     {
            
    //     }
    // }

    public void Setup()
    {
        score = Score.instance.score;
        pointsText.text = "HighScore :" + score.ToString();
        gameobject.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;
        body.constraints = RigidbodyConstraints2D.FreezePositionX;
        SoundManager.instance.PlaySound(won);

    }

    public void QuitButton()
    {
        SoundManager.instance.PlaySound(buttonSelectSound);
        Application.Quit();
        Debug.Log("Quit");
    }
}
