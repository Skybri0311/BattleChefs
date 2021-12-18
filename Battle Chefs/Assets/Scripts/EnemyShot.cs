using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float speed = 20f;
    public int eDamage = 50;
    public int shotTimer = 3;
    public Rigidbody2D rb;

    public HealthBar healthBar;

    private void Awake()
    {
        healthBar = FindObjectOfType<HealthBar>();
        //healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(CountdownTimer());

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            healthBar.LoseHealth();
            Debug.Log("Took Hit");
        }
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
    IEnumerator CountdownTimer()
    {
        yield return new WaitForSeconds(shotTimer);
        Destroy(gameObject);
    }
}
