using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    public float countdownDamageOff = 4;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Damage x 2 Active");
            StartCoroutine(DoubleDamage(other));
        }

    }
    IEnumerator DoubleDamage(Collider2D player)
    {
        //PowerOn
        Bullet.bulletDamage *= 2;
        //Countdown start
        yield return new WaitForSeconds(countdownDamageOff);
        Debug.Log("DoubleDamageOff");
        //PowerOff
        Bullet.bulletDamage /= 2;
        Destroy(gameObject);
    }
}
