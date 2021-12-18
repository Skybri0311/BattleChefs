using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int mainMenuIndex;
    public string deathMenuName;
    public int currentLevel;
    public int nextLevelIndex;
    public int firstLevel;
    public int savedScore;
    private Player player;
    public ScoreCounter scoreCounter;
    public LifeCounter lifeCounter;


    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void Respawn()
    {
        player.rb.position = player.startPosition;

    }

    public void Reload()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void NextLevel()
    {
        scoreCounter.SaveScore();
        Debug.Log("Go To Level" + nextLevelIndex);
        SceneManager.LoadScene(nextLevelIndex);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void BackToMainMenu()
    {
        scoreCounter.ResetScore();
        SceneManager.LoadScene(mainMenuIndex);
    }
    public void DeathMenu()
    {
        scoreCounter.ResetScore();
        SceneManager.LoadScene(deathMenuName);
    }

}
