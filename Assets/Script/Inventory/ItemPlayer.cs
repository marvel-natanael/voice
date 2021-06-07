using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemPlayer : MonoBehaviour
{
    public Text textGold, textAmmo, textGrenade, textHealthBox, ammoAmount, silverAmount;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ammoAmount.text = "Ammo : " + DataItemPlayer.ammo;
        silverAmount.text = ""+DataItemPlayer.grenade;
        textAmmo.text = "Ammo : " + DataItemPlayer.ammo;
        textGold.text = "Gold : " + DataItemPlayer.gold;
        textGrenade.text = "Grenade : " + DataItemPlayer.grenade;
        textHealthBox.text = "HealthBox : " + DataItemPlayer.healthBox;
    }
}
