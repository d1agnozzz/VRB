using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsWork : MonoBehaviour
{
    [SerializeField] GameObject expBomb;
    GameObject player;
    Collider newCollider;
    float x, z, xp, zp;
    RespawnProvider Bombs;

    private void Start()
    {
        Bombs = GameObject.Find("XR Rig").GetComponent<RespawnProvider>();
        player = GameObject.Find("Main Camera");
        newCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (transform.position.y < -1)
        {
            Bombs.bombsNumber++;
            Destroy(gameObject);
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            newCollider.enabled = false;
            x = Mathf.Ceil(transform.position.x) - 0.5f;
            z = Mathf.Ceil(transform.position.z) - 0.5f;
            xp = Mathf.Ceil(player.transform.position.x) - 0.5f;
            zp = Mathf.Ceil(player.transform.position.z) - 0.5f;
            if (!(Mathf.Abs(x - xp) > 1.5f || Mathf.Abs(z - zp) > 1.5f || Mathf.Abs(x - xp) > 0.5f && Mathf.Abs(z - zp) > 0.5f))
                Instantiate(expBomb, new Vector3(x, 0.5f, z), Quaternion.identity);
            else
                Bombs.bombsNumber++;
            Destroy(gameObject);
        }
    }
}
