using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPatrolAI : MonoBehaviour
{
    public List<Transform> points;
    public int nextID = 0;
    int idChangeValue = 1;
    public bool isFacingLeft;
    public int speed = 2;
    public int shootCooldown = 1;
    public int shotSpeed = 1;
    public float range;
    private float distToPlayer;
    private bool canPatrol;
    private bool canShoot;

    public Animator animator;
    public Transform player;
    public Transform shootPoint;
    public Rigidbody2D rb;
    public GameObject enemyShot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        canPatrol = true;
        canShoot = true;
        enemyShot = GameObject.Find("EnemyShot").GetComponent<GameObject>();
    
    }

    // Update is called once per frame
    private void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer <= range)
        {
            //if the player is on the side enemy is not facing, flip to face player
            if (player.transform.position.x < transform.position.x && isFacingLeft == false)
            {
                shootPoint.rotation = new Quaternion(0, 1, 0, 0);
                transform.localScale = new Vector3(1, 1, 1);
                isFacingLeft = true;
            }

            if(player.transform.position.x > transform.position.x && isFacingLeft == true)
            {
                shootPoint.rotation = new Quaternion(0, 0, 0, 0);
                transform.localScale = new Vector3(-1, 1, 1);
                isFacingLeft = false;
            }

            canPatrol = false;
            animator.SetBool("isShooting", true);
            rb.velocity = Vector2.zero;
            if(canShoot == true)
            StartCoroutine(Shoot());
        }
        else
        {
            canPatrol = true;
            animator.SetBool("isShooting", false);
        }
        if (canPatrol == true)
        {
            MoveToNextPoint();
        }
    }

    void MoveToNextPoint()
    {
        //Get the next point transform
        Transform goalPoint = points[nextID];
        //flip the enemy transform to look into the points direction
        Flip();
        //move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //check the distance between enemy and goal point to trigger next point
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            //Check if we are at the end of the line (make the change -1)
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            //Check if we are at the start of the line (make the change 1)
            if (nextID == 0)
                idChangeValue = 1;
            //Apply the change on the nextID
            nextID += idChangeValue;
        }
    }
    private void Flip()
    {
        Transform goalPoint = points[nextID];
        if (goalPoint.transform.position.x > transform.position.x)
        {
            shootPoint.rotation = new Quaternion(0, 0, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingLeft = false;
        }
        else
        {
            shootPoint.rotation = new Quaternion(0, 1, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
            isFacingLeft = true;
        }
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        GameObject newEnemyShot = Instantiate(enemyShot, shootPoint.position, shootPoint.rotation);
        newEnemyShot.GetComponent<Rigidbody2D>().velocity = new Vector2(shotSpeed * speed * Time.fixedDeltaTime, 0f);
        canShoot = true;
    }
}
