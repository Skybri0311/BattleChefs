using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public int playerAD;
    public float attackRange;
    public float attackSpeed = 1;
    public LayerMask enemyLayers;
    bool isAttacking;

    public Enemy enemy1;

    private void Awake()
    {
        enemy1 = FindObjectOfType<Enemy>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack") && !isAttacking)
        {
            Attack();
        }
        else if(Input.GetButtonUp("Attack") && isAttacking)
        {
            StartCoroutine(AttackCooldown());
        }
    }

    void Attack()
    {
        isAttacking = true;
        //Detect enemies in range of an overlap circle on the attack point
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage Enemy
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy1.TakeDamage();
            Debug.Log("Player Hit" + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackSpeed);
        isAttacking = false;
    }
}
