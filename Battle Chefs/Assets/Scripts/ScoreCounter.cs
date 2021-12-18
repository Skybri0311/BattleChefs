using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int currentScore;
    public Enemy enemyScore;
    public bool isLifeGem;
    public bool isScoreGem;
    public LevelController levelController;
    public ScoreGem scoreGem;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        enemyScore = FindObjectOfType<Enemy>();
        levelController = FindObjectOfType<LevelController>();
        scoreGem = FindObjectOfType<ScoreGem>();
    }

    public void Start()
    {
        currentScore = PlayerPrefs.GetInt("savedScore");
        scoreText.text = currentScore.ToString();
    }

    public void AddScore()
    {
        if(isLifeGem == true)
        {
            currentScore += scoreGem.gemPoints;
            scoreText.text = currentScore.ToString();
        }
        currentScore += enemyScore.points;
        scoreText.text = currentScore.ToString();
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt("savedScore", currentScore);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("savedScore", 0);
    }




}
