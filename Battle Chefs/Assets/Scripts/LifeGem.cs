using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            Destroy(gameObject);
        }
        Debug.Log(hitInfo.name);
    }
}
