using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBombWork : MonoBehaviour
{
    Collider newCollider, playerCollider;
    GameObject player;
    bool collideWithPlayer = false;
    float time = 0.5f;

    private void Awake()
    {
        player = GameObject.Find("XR Rig");
        newCollider = GetComponent<Collider>();
        playerCollider = player.GetComponent<Collider>();
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0 && !collideWithPlayer)
            newCollider.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " entered");
        if (other.gameObject.name == "XR Rig")
            collideWithPlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name + " exited");
        if (other.gameObject.name == "XR Rig")
            collideWithPlayer = false;
    }
}
