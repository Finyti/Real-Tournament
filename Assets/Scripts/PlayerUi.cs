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

    }

    void Update()
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
