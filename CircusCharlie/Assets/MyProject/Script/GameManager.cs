using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver = false;
    public TMP_Text Score_NOW;
    public GameObject gameoverUi;

    private int score = 0;
    private int bonusScore = 5000;
    private int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void AddScore(int newScore)
    {

        if (isGameOver == false)
        {
            score += newScore;
            Score_NOW.text = string.Format("Score : {0}", score);
            Debug.Log(score);
        }
    }
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUi.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
