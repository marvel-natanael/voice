using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public static int bulletDamage = 1;
 
    void Update()
    {
            transform.Translate(new Vector2(bulletSpeed * Time.deltaTime, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.gameObject.tag == "Enemy")
        {
            enemy.takeDamage(bulletDamage);
            Destroy(gameObject);
        }
        
    }
}
