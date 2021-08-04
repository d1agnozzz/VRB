using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPresence : MonoBehaviour
{
    public InputActionReference gripReference = null;
    public InputActionReference triggerReference = null;
    public GameObject handModelPrefab;

    GameObject handModel;
    Animator handAnimator;

    // Start is called before the first frame update
    private void Awake()
    {
        gripReference.action.started += Grip;
        gripReference.action.canceled += GripStop;
        triggerReference.action.started += Trigger;
        triggerReference.action.canceled += TriggerStop;
    }

    private void Start()
    {
        handModel = Instantiate(handModelPrefab, transform);
        handAnimator = handModel.GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        gripReference.action.started -= Grip;
        gripReference.action.canceled -= GripStop;
        triggerReference.action.started -= Trigger;
        triggerReference.action.canceled -= TriggerStop;
    }

    private void Grip(InputAction.CallbackContext context)
    {
        handAnimator.SetFloat("Grip", 1f);
    }

    private void GripStop(InputAction.CallbackContext context)
    {
        handAnimator.SetFloat("Grip", 0f);
    }

    private void Trigger(InputAction.CallbackContext context)
    {
        handAnimator.SetFloat("Trigger", 1f);
    }

    private void TriggerStop(InputAction.CallbackContext context)
    {
        handAnimator.SetFloat("Trigger", 0);
    }
}
