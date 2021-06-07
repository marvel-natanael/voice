using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject silverPrefab;
    public int bulletAmmo, silverAmmo;
    // Update is called once per frame

    private void Update()
    {
        bulletAmmo = DataItemPlayer.ammo;
        silverAmmo = DataItemPlayer.grenade;
    }

    public void Shoot()
    {
        //shooting
        if (bulletAmmo <= 0)
        {
            Debug.Log("Out of Ammo");
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            DataItemPlayer.ammo -= 1;
            Debug.Log(bulletAmmo);
        }

    }
    public void Silver()
    {
        if (silverAmmo <= 0)
        {
            Debug.Log("Out of Silver");
        }
        else
        {
            Instantiate(silverPrefab, firePoint.position, firePoint.rotation);
            DataItemPlayer.grenade -= 1;
            Debug.Log(silverAmmo);
        }
    }
}
