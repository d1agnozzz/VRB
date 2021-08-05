using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DWKill : MonoBehaviour
{
    [SerializeField] float spawnRate = 0.5f, interSpawnRate = 0.5f;
    [SerializeField] GameObject Inter1, Inter2, Inter3;
    private void Start()
    {
        if (Random.Range(0.0f, 1.0f) > spawnRate)
            Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (Random.Range(0.0f, 1.0f) < interSpawnRate)
            if (Random.Range(0.0f, 1.0f) < 0.33f)
                Instantiate(Inter1, transform.position, Quaternion.identity);
            else if (Random.Range(0.0f, 1.0f) < 0.5f)
                Instantiate(Inter2, transform.position, Quaternion.identity);
            else
                Instantiate(Inter3, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
