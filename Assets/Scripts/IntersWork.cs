using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersWork : MonoBehaviour
{
    [SerializeField] float rotSpeed, UDSpeed;
    [SerializeField] GameObject exploding;
    float rand;
    bool up = true;


    void Update()
    {
        transform.Rotate(0.0f, Time.deltaTime * rotSpeed, 0.0f);
        if (up)
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * UDSpeed, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * UDSpeed, transform.position.z);
        if (transform.position.y > 0.6f)
            up = false;
        else if (transform.position.y < 0.4f)
            up = true;
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
