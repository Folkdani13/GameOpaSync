using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Camera cam;
    public GameObject[] items ;
    private float maxWidth;
    private int score;
    private string testc;
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

       /* foreach (GameObject objects in GameObject.FindGameObjectsWithTag("Ball"))
        {
            if (objects.name == "Bomb")
            {
                items = items.remove("Bomb");
            }
        }
       // GameObject[] objects = GameObject.FindGameObjectsWithTag("Ball");
       

        List<GameObject> list = new List<GameObject>(items);
        list.Remove(GameObject.FindGameObjectsWithTag("Ball");
        */




        while (GameObject.Find("Kubel").GetComponent<Score>().timeLeft > 0)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Ball");
           // GameObject[] c = items.(objects).ToArray();
            score = GameObject.Find("Kubel").GetComponent<Score>().score;
            GameObject ball = items[Random.Range(0, items.Length)];
            
            Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            if (score < 50)
            {
                
                Instantiate(ball, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(Random.Range(2.0f, 3.0f));
            }
            else if (score <= 100)
            {
                Instantiate(ball, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(Random.Range(1.1f, 2.1f));
            }
            else if (score <= 499)
            {
                Instantiate(ball, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(Random.Range(0.5f, 0.5f));
            }
            else if (score >= 500)
            {
                Instantiate(ball, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(Random.Range(0.21f, 0.21f));
            }
          

        }
        
        yield return new WaitForSeconds(1.0f);
        gameOverText.SetActive(true);
        kubelcontroller.MoveControl(false);
        yield return new WaitForSeconds(1.0f);
        restartBtn.SetActive(true);
        

    }


}
