using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;
    private bool isPause = false;
    
    public static UI Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isPause)
        {
            Time.timeScale = 0f;
            isPause = true;
        }
        else if(Input.GetKeyDown(KeyCode.P) && isPause)
        {
            Time.timeScale = 1f;
            isPause = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void SetScore(int point)
    {
        score += point;
        scoreText.text = score.ToString() + " P";
    }
}
