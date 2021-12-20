using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public int damage = 25;
    public int points = 10;

    public PlayerCombat playerAttack;

    //public Shot Shot;
    public GameObject deathEffect;

    private void Awake()
    {
        playerAttack = FindObjectOfType<PlayerCombat>();
        //Shot = GameObject.Find("Shot").GetComponent<Shot>();
    }
    public void TakeDamage()
    {
        health -= playerAttack.playerAD;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Debug.Log("Enemy Dead");
        Destroy(gameObject);
    }

 
}
