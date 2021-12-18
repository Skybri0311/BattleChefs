using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGem : MonoBehaviour
{
    public int gemPoints = 20;
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
