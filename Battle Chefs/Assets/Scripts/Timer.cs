using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;
    public LevelController levelController;
    public LifeCounter lifeCounter;

    [SerializeField] Text countdownText;

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
        lifeCounter = FindObjectOfType<LifeCounter>();
    }
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime += Time.deltaTime  * -1;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            levelController.DeathMenu();
            currentTime = startingTime;
            // Your Code Here
        }
    }

    public void ResetTimer()
    {
        currentTime = startingTime;
    }
}
