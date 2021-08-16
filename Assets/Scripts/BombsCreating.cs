using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BombsCreating : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    public float diseaseTime = -1.0f;
    public InputActionReference gripReference = null;
    bool handIn = false;
    bool smthInHand = false;
    RespawnProvider Bombs;

    private void Update()
    {
        diseaseTime -= Time.deltaTime;
    }

    private void Awake()
    {
        Bombs = GameObject.Find("XR Rig").GetComponent<RespawnProvider>();
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
        if (handIn && !smthInHand && Bombs.bombsNumber > 0 && diseaseTime < 0.0f)
        {
            Instantiate(bomb, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Bombs.bombsNumber--;
        }
    }
}
