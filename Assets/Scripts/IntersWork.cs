using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IntersWork : MonoBehaviour
{
    [SerializeField] float rotSpeed, UDSpeed;
    [SerializeField] GameObject exploding;
    bool up = true;
    ActionBasedContinuousMoveProvider continuousMoveProvider;
    RespawnProvider Bombs;

    private void Start()
    {
        Bombs = GameObject.Find("XR Rig").GetComponent<RespawnProvider>();
        continuousMoveProvider = GameObject.Find("XR Rig").GetComponent<ActionBasedContinuousMoveProvider>();
    }

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

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "XR Rig")
        {
            if (name.Contains("SpUp"))
                continuousMoveProvider.moveSpeed += 0.5f;
            else if (name.Contains("SpDown"))
                continuousMoveProvider.moveSpeed -= 0.5f;
            else if (name.Contains("RUp"))
                exploding.GetComponent<ParticleSystem>().startLifetime += 0.1f;
            else if (name.Contains("RDown"))
            {
                if (exploding.GetComponent<ParticleSystem>().startLifetime > 0.15f)
                    exploding.GetComponent<ParticleSystem>().startLifetime -= 0.1f;
            }
            else if (name.Contains("BUp"))
                Bombs.bombsNumber++;
            else if (name.Contains("BDown"))
                if (Bombs.bombsNumber > 1.5f)
                    Bombs.bombsNumber--;
            Destroy(gameObject);
        }    
    }
}
