using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public LevelController levelController;

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
    }
    public void NewGameStart()
    {
        levelController.NewGame();
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
    
}
