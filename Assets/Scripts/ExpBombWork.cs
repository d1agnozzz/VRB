using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBombWork : MonoBehaviour
{
    [SerializeField] GameObject explod;
    [SerializeField] Collider newCollider;
    bool collideWithPlayer = false;
    float timeOfTrigger = 0.5f, timer = 3.0f;
    RespawnProvider Bombs;

    private void Awake()
    {
        Bombs = GameObject.Find("XR Rig").GetComponent<RespawnProvider>();
    }

    private void Update()
    {
        timeOfTrigger -= Time.deltaTime;
        timer -= Time.deltaTime;
        if (timeOfTrigger < 0 && !collideWithPlayer)
            newCollider.isTrigger = false;
        if (timer < 0)
        {
            Bombs.bombsNumber++;
            Instantiate(explod, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name + " entered");
        if (other.gameObject.name == "XR Rig")
            collideWithPlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.name + " exited");
        if (other.gameObject.name == "XR Rig")
            collideWithPlayer = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        Bombs.bombsNumber++;
        Instantiate(explod, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
        Destroy(gameObject);
    }
}
