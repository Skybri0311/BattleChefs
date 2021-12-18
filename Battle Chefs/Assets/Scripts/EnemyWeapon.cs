using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyShotPrefab;

    //Create logic for ai firing
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Shooting Logic
        Instantiate(enemyShotPrefab, firePoint.position, firePoint.rotation);
    }
}
