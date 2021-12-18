using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;
    public bool gameOver = false;
    public LevelController levelController;
    public bool isDead = false;

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
    }
    public void IsDead(bool isDead)
    {
        if (isDead == true)
            LoseLife();
    }

    public void LoseLife()
    {

        //Decrease the value of livesRemmaining
        livesRemaining--;
        //Hide one of the life images
        lives[livesRemaining].enabled = false;

        //If player run out of lives we loose the game
        if(livesRemaining == 0)
        {
            Debug.Log("You Lose");
            gameOver = true;
            levelController.DeathMenu();
        }
    }

    public void AddLife()
    {
        //if player lives are full do nothing
        if (livesRemaining == 3)
        {
            Debug.Log("Lives Full");
            return;
        }
        //Increase value of livesRemaining
        livesRemaining ++;
        Debug.Log("Life Added");
        //Show one of the hidden life images
        lives[livesRemaining -1].enabled = true;

    }
}
