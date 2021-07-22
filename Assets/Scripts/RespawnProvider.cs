using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnProvider : MonoBehaviour
{
    [SerializeField] GameObject spawn;
    private void OnParticleCollision(GameObject other)
    {
        transform.position = new Vector3(0.5f, 0.05f, -5.5f);
        Instantiate(spawn, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
    }
}
