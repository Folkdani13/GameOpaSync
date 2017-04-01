using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Score : MonoBehaviour {

    public Text scoreText;
    public Text timerText;
    public int ballValue;
    public int score;
    public string test;
    public float timeLeft;
 

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScoreandTxt();
        
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
            UpdateScoreandTxt();
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
                UpdateScoreandTxt();
                break;
            case "Ball":
                score += ballValue*20;
                timeLeft += 2;
                UpdateScoreandTxt();
                break;
            case "Gesicht":
                score += ballValue*10;
                timeLeft += 5;
                UpdateScoreandTxt();
                break;
        }
        
    }
    
    void UpdateScoreandTxt()
    {
        scoreText.text = "Score: \n" + score;
        timerText.text = "Time Left: \n" + Mathf.RoundToInt(timeLeft);

    }
}
