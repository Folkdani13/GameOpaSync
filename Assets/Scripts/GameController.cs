using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Camera cam;
    public GameObject[] items ;
    private float maxWidth;
    public float timeLeft;
    public bool playing;
    public KubelController kubelcontroller;
    public GameObject gameOverText;
    public GameObject restartBtn;
    public GameObject splashScreen;
    public GameObject startButton;
        


    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        playing = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        maxWidth = targetWidth.x-1.0f;
        

    }

    public void StartGame()
    {
        splashScreen.SetActive(false);
        startButton.SetActive(false);
        kubelcontroller.MoveControl(true);
        StartCoroutine(Spawn());
    }
   

    IEnumerator Spawn()
    {
       
        yield return new WaitForSeconds(1.0f);
        playing = true;
        while (GameObject.Find("Kubel").GetComponent<Score>().timeLeft > 0)
        {
            GameObject ball = items[Random.Range(0, items.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f,3.0f));
        }

        yield return new WaitForSeconds(1.0f);
        gameOverText.SetActive(true);
        kubelcontroller.MoveControl(false);
        yield return new WaitForSeconds(1.0f);
        restartBtn.SetActive(true);
        

    }


}
