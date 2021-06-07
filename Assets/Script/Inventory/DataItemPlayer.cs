using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataItemPlayer : MonoBehaviour
{
    public static int gold = 100, ammo = 10, grenade = 1, healthBox = 1;
    private int goldReset = 100, ammoReset = 10, grenadeReset = 1,healthBoxReset=1;
    public void ResetData()
    {
        gold = goldReset;
        ammo = ammoReset;
        grenade = grenadeReset;
        healthBox = healthBoxReset; 
    }

}
