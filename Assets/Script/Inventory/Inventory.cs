using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject Menu;
    private void Start()
    {
        inventory = GameObject.FindWithTag("ShopMenu");
        inventory.SetActive(false);
    }

    private void Update()
    {
        if (DataInventory.showInventory)
        {
            inventory.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Menu.SetActive(true);
        }
    }
    public void Hide()
    {
        Menu.SetActive(false);
    }

    public void Show()
    {
        DataInventory.showInventory = true;
        Hide();
    }

    public void Resume()
    {
        DataInventory.showInventory = false;
        Time.timeScale = 1f;
        inventory.SetActive(false);
    }

    public void AddAmmo()
    {
        if (DataItemPlayer.gold >= 15)
        {
            DataItemPlayer.ammo += 10;
            DataItemPlayer.gold -= 15;
        }
    }

    public void AddGrenade()
    {
        if (DataItemPlayer.gold >= 20)
        {
            DataItemPlayer.grenade += 1;
            DataItemPlayer.gold -= 20;
        }
    }

    public void AddHealthBox()
    {
        if (DataItemPlayer.gold >= 35)
        {
            DataItemPlayer.healthBox += 1;
            Char.health += 1;
            DataItemPlayer.gold -= 35;
        }
    }

    public void sellAmmo()
    {
        if(DataItemPlayer.ammo >= 1)
        {
            DataItemPlayer.ammo -= 1;
            DataItemPlayer.gold += 10;
        }
    }
    public void sellGrenade()
    {
        if (DataItemPlayer.grenade >= 1)
        {
            DataItemPlayer.grenade -= 1;
            DataItemPlayer.gold += 25;
        }
    }
    public void sellHealthBox()
    {
        if (DataItemPlayer.healthBox >= 1)
        {
            DataItemPlayer.healthBox -= 1;
            DataItemPlayer.gold += 100;
        }
    }
}
