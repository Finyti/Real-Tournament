using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{

    public TextMeshProUGUI bulletText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI equipText;

    public Weapon weapon;
    public Health health;



    void Start()
    {

        UpdateUI();
        health.onDamage.AddListener(UpdateUI);


    }
    void Update()
    {
        if (weapon != null)
        {
            UpdateUI();
            weapon.onShoot.AddListener(UpdateUI);
            weapon.onReload.AddListener((ended) => UpdateUI());
        }
        else
        {
            UpdateUI();
            equipText.text = "None";
        }
    }
    void UpdateUI()
    {

        if (weapon != null)
        {
            equipText.text = weapon.name;
            bulletText.text = weapon.currentAmmo.ToString() + "/" + weapon.ammoReset.ToString();
        }
        else
        {
            bulletText.text = "0/0";
        }


        if (health != null)
        {
            healthText.text = health.health.ToString();
        }

    }
}
