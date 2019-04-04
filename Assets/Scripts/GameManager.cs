using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public Text scoreText; 
    private int score = 0;

    public Text highScoreText;
    public static int highScore;

    public GameObject gameOverText;
    public bool isGameOver;

    public float meteroSpeed = -2f;

    

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        highScoreText.text = "Highscore: " + highScore.ToString();
        highScore = PlayerPrefs.GetInt("highScore", highScore);
        
    }
    // Update is called once per frame
    void Update () {
		if (GameManager.Instance.isGameOver == true && Input.GetButton("Jump"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("reload scene");
        }

        if (score > highScore)
        {
            highScore = score;
            
            PlayerPrefs.SetInt("highScore", highScore);
        }
        highScoreText.text = "Highscore: " + highScore.ToString();
    }
    public void AddScore()
    {
        score++;
        
        scoreText.text = "Score: " + score;

        meteroSpeed += score / -100f;
    }
    public void EndGame()
    {
        gameOverText.SetActive(true);
        isGameOver = true;
    }
}
