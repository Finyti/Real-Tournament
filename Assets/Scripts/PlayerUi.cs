using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{

    public TextMeshProUGUI bulletText;
    public TextMeshProUGUI healthText;

    public Weapon weapon;
    public Health health;

    void Start()
    {
        UpdateUI();
        health.onDamage.AddListener(UpdateUI);
        weapon.onShoot.AddListener(UpdateUI);
        weapon.onReload.AddListener((ended) => UpdateUI());
    }
    void UpdateUI()
    {
        if (bulletText != null)
        {
            bulletText.text = weapon.currentAmmo.ToString() + "/" + weapon.ammoReset.ToString();
        }
        if (health != null)
        {
            healthText.text = health.health.ToString();
        }

    }
}
