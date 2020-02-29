using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreHandler : MonoBehaviour
{
    public Text yourScore,highScore;
    // Start is called before the first frame update
    void Start()
    {
        String temp = PlayerPrefs.GetInt("tempscore", 0).ToString();
        yourScore.text = "Your Score : " + temp;

        if(int.Parse(temp) > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", int.Parse(temp));
            highScore.text = temp;
        }
        else
        {
            highScore.text = "High Score : " + PlayerPrefs.GetInt("highscore").ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
