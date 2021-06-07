using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthEnemy = 3;
    public int damageEnemy = 1;
    private void Update()
    {
        if(healthEnemy <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void takeDamage(int dmg)
    {
        healthEnemy -= dmg;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Char player = collision.GetComponent<Char>();
        {
            if(collision.CompareTag("Player"))
            {
                player.charTakeDamage(damageEnemy);
            }
        }
        
    }
}
