using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int health = 10;
    public bool shouldDestroy = true;

    public GameObject damagePrefab;
    public GameObject diePrefab;

    public UnityEvent onDie;
    public UnityEvent onDamage;
    void Start()
    {
        
    }


    void Update()
    {

    }

    public void Die()
    {
        if(diePrefab != null)
        {
            Instantiate(diePrefab, transform.position, Quaternion.identity);
        }
        if (shouldDestroy)
        {
            Destroy(gameObject);
        }

        onDie.Invoke();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Bullet"))
        {
            Damage(collision.gameObject.GetComponent<Bullet>().damage);
        }
    }

    public void Damage(int dmg)
    {
        if (damagePrefab != null)
        {
            Instantiate(damagePrefab, transform.position, Quaternion.identity);
        }
        health -= dmg;

        if (health < 0)
        {
            health = 0;
        }

        onDamage.Invoke();

        if (health <= 0)
        {
            Die();
        }

    }
}
