using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
        DataItemPlayer.gold = 100;
        DataItemPlayer.ammo = 10;
        DataItemPlayer.grenade = 10;
        DataItemPlayer.healthBox = 1;
    }
}
