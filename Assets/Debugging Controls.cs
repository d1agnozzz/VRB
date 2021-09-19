// GENERATED AUTOMATICALLY FROM 'Assets/Debugging Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DebuggingControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DebuggingControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Debugging Controls"",
    ""maps"": [
        {
            ""name"": ""Mouse Keyboard"",
            ""id"": ""b8db5794-056f-4df3-8104-740c5b77453e"",
            ""actions"": [
                {
                    ""name"": ""MoveToPointer"",
                    ""type"": ""Button"",
                    ""id"": ""66923516-4501-4a06-bbad-93861b4afb77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9cce60ad-f89b-4f63-bf33-8798bd62e515"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveToPointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mouse Keyboard
        m_MouseKeyboard = asset.FindActionMap("Mouse Keyboard", throwIfNotFound: true);
        m_MouseKeyboard_MoveToPointer = m_MouseKeyboard.FindAction("MoveToPointer", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Mouse Keyboard
    private readonly InputActionMap m_MouseKeyboard;
    private IMouseKeyboardActions m_MouseKeyboardActionsCallbackInterface;
    private readonly InputAction m_MouseKeyboard_MoveToPointer;
    public struct MouseKeyboardActions
    {
        private @DebuggingControls m_Wrapper;
        public MouseKeyboardActions(@DebuggingControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveToPointer => m_Wrapper.m_MouseKeyboard_MoveToPointer;
        public InputActionMap Get() { return m_Wrapper.m_MouseKeyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseKeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IMouseKeyboardActions instance)
        {
            if (m_Wrapper.m_MouseKeyboardActionsCallbackInterface != null)
            {
                @MoveToPointer.started -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnMoveToPointer;
                @MoveToPointer.performed -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnMoveToPointer;
                @MoveToPointer.canceled -= m_Wrapper.m_MouseKeyboardActionsCallbackInterface.OnMoveToPointer;
            }
            m_Wrapper.m_MouseKeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveToPointer.started += instance.OnMoveToPointer;
                @MoveToPointer.performed += instance.OnMoveToPointer;
                @MoveToPointer.canceled += instance.OnMoveToPointer;
            }
        }
    }
    public MouseKeyboardActions @MouseKeyboard => new MouseKeyboardActions(this);
    public interface IMouseKeyboardActions
    {
        void OnMoveToPointer(InputAction.CallbackContext context);
    }
}
