using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 10;
    void Start()
    {
        
    }


    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Bullet"))
        {
            health -= collision.gameObject.GetComponent<Bullet>().damage;
        }
    }
}
