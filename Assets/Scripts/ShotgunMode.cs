using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunMode : MonoBehaviour
{
    public Weapon weapon;
    public bool activated;
    public int bulletsMod = 3;
    public void SwitchMode()
    {
        activated = !activated;

        weapon.bulletsPerShot = activated ? bulletsMod : 1;

    }


    public void Burst()
    {
        weapon.fireInterval = 0;
        weapon.Shot();
        weapon.Shot();
        weapon.Shot();
        weapon.Shot();
        weapon.fireInterval = 0.5f;

    }

}
