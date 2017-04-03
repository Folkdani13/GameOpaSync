using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Score : MonoBehaviour {

    public Text scoreText;
    public Text timerText;
    public Text lifeText;
    public int death;
    public int ballValue;
    public int score;
    public string test;
    public float timeLeft;
 

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateLife();
        UpdateScoreandTime();
        
	}

    void FixedUpdate()
    {
        if (GameObject.Find("Controller").GetComponent<GameController>().playing)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 0;
            }
            UpdateScoreandTime();
        }
    } 

    void OnTriggerEnter2D(Collider2D target)
    {
        test = target.tag;
        switch (test)
        {
            case "Bomb":
                score -= ballValue*2;
                timeLeft -= 2;
                UpdateScoreandTime();
                break;
            case "Ball":
                score += ballValue*20;
                UpdateScore();
                break;
            case "Gesicht":
                timeLeft += 5;
                UpdateTime();
                break;
            case "Skull":
                if (death == 1)
                {
                    death -= 1;
                    UpdateLife();
                    timeLeft = 0;
                    UpdateTime();
                }
                else
                {
                    death -= 1;
                    UpdateLife();
                }
                break;
        }
        
    }
    
    void UpdateScoreandTime()
    {
        scoreText.text = "Score: \n" + score;
        timerText.text = "Time Left: \n" + Mathf.RoundToInt(timeLeft);

    }
    void UpdateTime()
    {
        timerText.text = "Time Left: \n" + Mathf.RoundToInt(timeLeft);

    }
    void UpdateScore()
    {
        scoreText.text = "Score: \n" + score;

    }
    void UpdateLife()
    {
        lifeText.text = "Leben: \n" + death;

    }
}

