using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float countdownSpeedOn = 1;
    public float countdownSpeedOff = 4;
    private bool on = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("SuperSpeed Active");
            StartCoroutine(SuperSpeed(other));
        }

    }
    IEnumerator SuperSpeed(Collider2D player)
    {
        //PowerOn
        Char stats = player.GetComponent<Char>();
        Debug.Log("Wait 1 sec");
        if (on)
        {
            stats.moveSpeed = 0f;
            yield return new WaitForSeconds(countdownSpeedOn);
            Debug.Log("SuperSpeedOn");
            stats.moveSpeed += stats.defSpeed;
            stats.moveSpeed *= 2f;
            on = false;
        }

        //Countdown start
        yield return new WaitForSeconds(countdownSpeedOff);
        Debug.Log("SuperSpeedOff");
        //PowerOff
        stats.moveSpeed = stats.moveSpeed / 2f;
        Destroy(gameObject);
    }
}
