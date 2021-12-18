using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapController : MonoBehaviour
{
    public LevelController levelController;
    public LifeCounter lifeCounter;
    public Timer timer;

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
        lifeCounter = FindObjectOfType<LifeCounter>();
        timer = FindObjectOfType<Timer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lifeCounter.LoseLife();
            Debug.Log("Trapped");
            levelController.Respawn();
        }
    }
}
