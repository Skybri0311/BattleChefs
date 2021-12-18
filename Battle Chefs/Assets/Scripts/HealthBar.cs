using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;
    public bool isDead = false;
    private bool isEnemyShot = false;
    
    private LifeCounter lifeCounter;
    private LevelController levelController;
    private Enemy enemy_damage;
    private EnemyShot enemyShot;
    private ScoreCounter scoreCounter;
    private void Awake()
    {
        lifeCounter = FindObjectOfType<LifeCounter>();
        levelController = FindObjectOfType<LevelController>();
        enemy_damage = FindObjectOfType<Enemy>();
        enemyShot = FindObjectOfType<EnemyShot>();
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }


    public void LoseHealth()
    {
        if (isEnemyShot)
            health -= enemyShot.eDamage;
        //Reduce the health
        health -= enemy_damage.damage;
        Debug.Log("Health" + health);
        //Refresh the UI fill bar
        fillBar.fillAmount = health / 100;
        //Check if health is 0 or less
        if(health==0)
        {
            Debug.Log("You Die");
            Die();
        }
    }
    void Die()
    {
        //set the is dead bool in HealthBar script and in LifeCounter scipt
        isDead = true;
        lifeCounter.IsDead(isDead = true);
        isDead = false;
        lifeCounter.IsDead(isDead = false);
        //Reset health to 100 and reset the fill to the new health
        health = 100;
        fillBar.fillAmount = health;
        //Reset player to start position do not reset level
        levelController.Respawn();
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            LoseHealth();
        }
        Debug.Log(hitInfo.name);

        LifeGem lifegem = hitInfo.GetComponent<LifeGem>();
        if (lifegem != null)
        {
            lifeCounter.AddLife();
        }
        Debug.Log(hitInfo.name);

        ScoreGem scoreGem = hitInfo.GetComponent<ScoreGem>();
        if(scoreGem != null)
        {
            scoreCounter.isScoreGem = true;
            scoreCounter.AddScore();
        }

        EnemyShot enemyShot = hitInfo.GetComponent<EnemyShot>();
        if (enemyShot != null)
        {
            isEnemyShot = true;
;
        }
        Debug.Log(hitInfo.name);
 
    }
}
