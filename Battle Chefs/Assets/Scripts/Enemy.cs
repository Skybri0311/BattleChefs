using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public int damage = 25;
    public int points = 10;

    public Shot Shot;
    public GameObject deathEffect;

    private void Awake()
    {
        //Shot = GameObject.Find("Shot").GetComponent<Shot>();
    }
    public void TakeDamage()
    {
        health -= Shot.sDamage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

 
}
