using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {

    public Text scoreText;
    public Text timerText;
    public int ballValue;
    private int score;
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

    void OnTriggerEnter2D()
    {
        score += ballValue;
        timeLeft += 2;
        UpdateScoreandTxt();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            score -= ballValue * 2;
            UpdateScoreandTxt();
            Destroy(GameObject.FindGameObjectWithTag("Bomb"));
        }

    }

    void UpdateScoreandTxt()
    {
        scoreText.text = "Score: \n" + score;
        timerText.text = "Time Left: \n" + Mathf.RoundToInt(timeLeft);

    }
}
