using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BombsCreating : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    public InputActionReference gripReference = null;
    bool handIn = false;
    bool smthInHand = false;

    private void Awake()
    {
        gripReference.action.started += NewBomb;
    }

    private void OnDestroy()
    {
        gripReference.action.started -= NewBomb;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Belt")
        {
            handIn = true;
            //Debug.Log("In");
        }
        else
        {
            smthInHand = true;
            //Debug.Log("InHand");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Belt")
        {
            handIn = false;
            //Debug.Log("Out");
        }
        else
        {
            smthInHand = false;
            //Debug.Log("HandWithout");
        }
    }

    private void NewBomb(InputAction.CallbackContext context)
    {
        if (handIn && !smthInHand)
        {
            Instantiate(bomb, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //Debug.Log("Created");
        }
    }
}
