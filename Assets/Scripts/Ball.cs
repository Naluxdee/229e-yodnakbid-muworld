using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D bullet)
    {
        
        if (bullet.CompareTag("Enemy"))
        {
            
            Destroy(bullet.gameObject); 
            Destroy(gameObject); 

        }
    }
}
