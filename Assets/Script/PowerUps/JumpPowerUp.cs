using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public float countdown = 4;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Superjump Active");
            StartCoroutine(superjump(other));
        }
    }
    IEnumerator superjump(Collider2D player)
    {
        //PowerOn
        Char stats = player.GetComponent<Char>();
        stats.jumpHeight*=2;
        //Countdown start
        yield return new WaitForSeconds(countdown);
        Debug.Log("SuperjumpOff");
        //PowerOff
        stats.jumpHeight = stats.jumpHeight/2;
        Destroy(gameObject);
    }
}
