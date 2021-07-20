using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsWork : MonoBehaviour
{
    [SerializeField] GameObject expBomb;
    Collider newCollider;
    float x, z;

    private void Start()
    {
        newCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            newCollider.enabled = false;
            x = Mathf.Ceil(transform.position.x) - 0.5f;
            z = Mathf.Ceil(transform.position.z) - 0.5f;
            Instantiate(expBomb, new Vector3(x, 0.5f, z), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
