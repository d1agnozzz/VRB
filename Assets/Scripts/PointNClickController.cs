using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PointNClickController : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject spawnObject;
    private DebuggingControls _input;

    private void Awake()
    {
        _input = new DebuggingControls();

        _input.MouseKeyboard.MoveToPointer.performed += context => Point();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }


    void Start()
    {
        mainCamera = Camera.main;

    }

    private void Point()
    {
        //Debug.Log("LMB clicked");
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()), out hit))
        {
            GameObject bombTemp = Object.Instantiate(spawnObject, hit.point, Quaternion.identity);
        }
    }
}
