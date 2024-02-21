using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int ammoReset = 10;
    public int currentAmmo = 10;
    public float reloadTime = 1;
    public bool isReloading = false;
    public bool isAutoFire = false;
    public float fireInterval = 0.5f;
    public float fireCooldown = 0;

    public int bulletsPerShot = 1;

    public float recoilAngle = 0;

    public UnityEvent onRightClick;



    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !isAutoFire)
        {
            Shot();
        }
        if (Input.GetKey(KeyCode.Mouse0) && isAutoFire)
        {
            Shot();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            onRightClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        if(fireCooldown > 0)
        {
            fireCooldown -= Time.deltaTime;
        }



    }
    public void Shot()
    {
        if(currentAmmo <= 0)
        {
            Reload();
            return;
        }
        if (!isReloading && fireCooldown <= 0)
        {
            fireCooldown = fireInterval;
            currentAmmo -= 1;

            for (int i = 0; i < bulletsPerShot; i++)
            {
                var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                var offsetX = Random.Range(-recoilAngle, recoilAngle);
                var offsetY = Random.Range(-recoilAngle, recoilAngle);
                bullet.transform.eulerAngles += new Vector3(offsetX, offsetY, 0);
            }

        }



    }

    async void Reload()
    {
        if (isReloading) return;
        if(currentAmmo == ammoReset) return;
        isReloading = true;


        await new WaitForSeconds(reloadTime);

        currentAmmo = ammoReset;
        isReloading = false;
        print("Reloaded");
    }
}
