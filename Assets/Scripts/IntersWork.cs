using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IntersWork : MonoBehaviour
{
    [SerializeField] float rotSpeed, UDSpeed;
    bool up = true;
    ActionBasedContinuousMoveProvider continuousMoveProvider;

    private void Start()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "XR Rig")
        {
            if (gameObject.name.Contains("SpUp"))
                continuousMoveProvider.moveSpeed += 0.5f;
            else if (gameObject.name.Contains("SpDown"))
                continuousMoveProvider.moveSpeed -= 0.5f;
            Destroy(gameObject);
        }    
    }
}
