using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsWork : MonoBehaviour
{
    [SerializeField] GameObject expBomb;
    // Owner is the one who planted the bomb (before there was just "Transform player" var)     
    public Bomberman owner;
    [SerializeField] Collider newCollider;
    float x, z, xp, zp;
    RespawnProvider Bombs;


    public static void Instantiate(Bomberman owner)
    {
        GameObject temp = Instantiate(owner.bombPrefab, owner.transform.position, owner.transform.rotation);
        temp.GetComponent<BombsWork>().SetOwner(owner);
    }

    public void SetOwner(Bomberman _owner)
    {
        owner = _owner;
    }

    private void Start()
    {
        Bombs = GameObject.Find("XR Rig").GetComponent<RespawnProvider>();
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
            xp = Mathf.Ceil(owner.transform.position.x) - 0.5f;
            zp = Mathf.Ceil(owner.transform.position.z) - 0.5f;
            if (!(Mathf.Abs(x - xp) > 1.5f || Mathf.Abs(z - zp) > 1.5f || Mathf.Abs(x - xp) > 0.5f && Mathf.Abs(z - zp) > 0.5f))
            {
                GameObject temp = Instantiate(expBomb, new Vector3(x, 0.5f, z), expBomb.transform.rotation);
                temp.GetComponent<ExpBombWork>().SetOwner(owner);

            }
            else
                Bombs.bombsNumber++;
            Destroy(gameObject);
        }
    }
}
