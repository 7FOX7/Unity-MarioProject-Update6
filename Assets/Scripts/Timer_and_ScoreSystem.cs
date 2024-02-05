using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class Timer_and_ScoreSystem : MonoBehaviour
{
    public int score = 0;
    private float timeLeft = 150f;
    public Text timerText;
    public Text scoreText;
    private string _time; 
    // Start is called before the first frame update

    void Start()
    {
        DataManagement.data.LoadData();
        _time = ""; 
    }

    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            UpdateTime(); 
        }
    }

    void UpdateTime()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        _time = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = $"Time: {_time}";
        timeLeft -= Time.deltaTime; 
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        // count the score here: 
        if (trig.gameObject.name == "EndLevel")
        {
            score = CountScoreWhenReachEnd();
            scoreText.text = $"Score: {score}";
            OnReachEnd(); 
        }

        if (trig.gameObject.name == "Coin") 
        {
            Debug.Log("You touch the coin"); 
            score = CountScoreCoin();
            scoreText.text = $"Score: {score}";
            Destroy(trig.gameObject);
        }
    }

    private void OnReachEnd()
    {
        Debug.Log($"Data says high is currently: {DataManagement.data.highScore}");
        DataManagement.data.highScore = score;
        DataManagement.data.SaveData();
        Debug.Log(DataManagement.data.highScore); 
    }

    int CountScoreWhenReachEnd()
    {
        // Data is displayed when we reach the end: 
        // Debug.Log("Data says high score is currently" + DataManagement.data.highScore);
        score += (int)(timeLeft * 10);
        return score;
    }

    int CountScoreCoin()
    {
        score += 10;
        return score;
    }
}