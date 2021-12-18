using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public LevelController levelController;

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelController.NextLevel();       
        }
    }
}
