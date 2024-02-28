using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Health health;

    public Weapon weapon;

    public LayerMask weaponLayer;

    public Transform hand;


    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        var cam = Camera.main.transform;
        var collider = Physics.Raycast(cam.position, cam.forward, out var hit, 3, weaponLayer);

        if (collider && Input.GetKey(KeyCode.E))
        {
            var clickedWeapon = hit.collider.gameObject;
            if (weapon != null)
            {
                Unequip();
            }
            Equip(clickedWeapon);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if (weapon != null)
            {
                Unequip();
            }
        }


        if (weapon == null) return;
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && !weapon.isAutoFire)
        {
            weapon.Shot();
        }
        if (Input.GetKey(KeyCode.Mouse0) && weapon.isAutoFire)
        {
            weapon.Shot();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            weapon.onRightClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health.Damage(1);
        }

    }

    public void Equip(GameObject clickedWeapon)
    {
        weapon = clickedWeapon.GetComponent<Weapon>();
        clickedWeapon.transform.parent = hand;
        clickedWeapon.GetComponent<Rigidbody>().isKinematic = true;
        clickedWeapon.transform.position = hand.position;
        clickedWeapon.transform.eulerAngles = hand.eulerAngles;

        GetComponent<PlayerUi>().weapon = weapon;
    }

    public void Unequip()
    {
        weapon.transform.parent = null;
        weapon.GetComponent<Rigidbody>().isKinematic = false;
        weapon = null;

        GetComponent<PlayerUi>().weapon = weapon;


    }
}
