using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public GameObject destroyPrefab;
    public GameObject flyPrefab;
    public GameObject hitPrefab;

    public int bounceCount = 3;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        print("F");
        Instantiate(flyPrefab, transform.position, Quaternion.identity);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if(bounceCount > 0)
        {
            transform.forward = other.contacts[0].normal;

            var hole = Instantiate(hitPrefab, transform.position, transform.rotation);

            bounceCount--;
        }
        else
        {
            Instantiate(destroyPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }



    }
}
