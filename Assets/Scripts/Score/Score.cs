using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreText;
    public int score {get; private set;}
    

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint(int point)
    {
        score += point;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("highscore" , score);

    }
}
