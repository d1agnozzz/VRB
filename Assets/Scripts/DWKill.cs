using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DWKill : MonoBehaviour
{
    [SerializeField] float spawnRate = 0.5f;
    private void Start()
    {
        if (Random.Range(0.0f, 1.0f) > spawnRate)
            Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
