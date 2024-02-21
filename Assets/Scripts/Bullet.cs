using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        print("F");
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
