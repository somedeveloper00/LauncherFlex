//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Inputs/MainNav.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MainNav : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainNav()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainNav"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""57ff5169-29f9-4bad-a100-a1d450b50ebe"",
            ""actions"": [
                {
                    ""name"": ""Next"",
                    ""type"": ""Button"",
                    ""id"": ""2c6d726d-9b04-40bf-b928-6abef7d98d7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Previous"",
                    ""type"": ""Button"",
                    ""id"": ""46e69544-47b7-435c-b612-64f46034777a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""482ae492-f4b9-424a-8375-3b39c4619672"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""8d5ad9f4-f150-4eba-8fd7-12e5c83bd0af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""240cf7c4-0d2a-4133-805d-33832635b968"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b191fed1-bd50-42da-b05d-8ec019a67c01"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d380d37-b4c4-4d3a-ad1c-c69bad0da97b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bf514e6-63d5-4541-b1ad-c5d041d0866e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77ec65f6-0688-4b03-b3d5-74f45db0403e"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4df72c5-3673-4dc3-9fde-4cc4886519de"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""839d7cd8-a037-4441-955f-a508b90ffbcf"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b40666cc-c3b7-4077-84ff-6cf86d7cf1d0"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af19964d-04fb-4f5c-8e35-10b7b3615dad"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff0ccd9c-d270-4db4-a135-c3eab90ca7ee"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bccf867a-86da-486a-bd50-922329a2ca87"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7e8d7d8-d4e3-477c-9994-227697dd80b4"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7108a6dd-7bc5-4235-b488-bbb23dd7696b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""035fc1ea-3d1a-433a-a6f7-a70d830ca3b4"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Overlay"",
            ""id"": ""ef3d207a-10c7-4d2a-a072-61b1e3bce89f"",
            ""actions"": [
                {
                    ""name"": ""Next"",
                    ""type"": ""Button"",
                    ""id"": ""8162c8d6-677b-4c95-8bf7-5a24a5567b65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Previous"",
                    ""type"": ""Button"",
                    ""id"": ""f7c790aa-6746-4a50-b299-58ccff0e0f32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""f43a9ca1-b297-4ac7-9b09-7dae4509c67c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""c394a2f0-9a8e-4d42-afd6-09dd6f3fe875"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5f7769ea-ab8b-4d9e-9cea-43835173b8ad"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3747fd94-6d4e-406e-84df-62efc889c68b"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0b0b70a-67ed-4ecb-80b0-969c7aad9832"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7e88378-8536-4867-9805-4901f84593c3"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1801ea8e-975b-4f66-9802-edc0ec031ea3"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0430458b-e48f-4b7e-9694-43ff5d2aa7a1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9985ec8-8a29-4152-892b-66d2ee4c884a"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc2730b8-5cd9-47ea-8993-55fd6879010f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf8cb1ad-d0fe-485f-8531-be797e8d4ad3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6584efa5-53a9-4f38-8487-aee58f75aca2"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55e90ee1-e193-4150-b3ef-7c84d82e9816"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""185d0cd8-961a-4ecf-9c30-b98b906634bc"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce5b3f3e-1ed6-4fb1-b435-391cd2f47f9c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""580a5870-acd2-4e5e-b5b6-9a3fde3d8f83"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Next = m_Main.FindAction("Next", throwIfNotFound: true);
        m_Main_Previous = m_Main.FindAction("Previous", throwIfNotFound: true);
        m_Main_Select = m_Main.FindAction("Select", throwIfNotFound: true);
        m_Main_Back = m_Main.FindAction("Back", throwIfNotFound: true);
        // Overlay
        m_Overlay = asset.FindActionMap("Overlay", throwIfNotFound: true);
        m_Overlay_Next = m_Overlay.FindAction("Next", throwIfNotFound: true);
        m_Overlay_Previous = m_Overlay.FindAction("Previous", throwIfNotFound: true);
        m_Overlay_Select = m_Overlay.FindAction("Select", throwIfNotFound: true);
        m_Overlay_Back = m_Overlay.FindAction("Back", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Next;
    private readonly InputAction m_Main_Previous;
    private readonly InputAction m_Main_Select;
    private readonly InputAction m_Main_Back;
    public struct MainActions
    {
        private @MainNav m_Wrapper;
        public MainActions(@MainNav wrapper) { m_Wrapper = wrapper; }
        public InputAction @Next => m_Wrapper.m_Main_Next;
        public InputAction @Previous => m_Wrapper.m_Main_Previous;
        public InputAction @Select => m_Wrapper.m_Main_Select;
        public InputAction @Back => m_Wrapper.m_Main_Back;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Next.started -= m_Wrapper.m_MainActionsCallbackInterface.OnNext;
                @Next.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnNext;
                @Next.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnNext;
                @Previous.started -= m_Wrapper.m_MainActionsCallbackInterface.OnPrevious;
                @Previous.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnPrevious;
                @Previous.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnPrevious;
                @Select.started -= m_Wrapper.m_MainActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnSelect;
                @Back.started -= m_Wrapper.m_MainActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Next.started += instance.OnNext;
                @Next.performed += instance.OnNext;
                @Next.canceled += instance.OnNext;
                @Previous.started += instance.OnPrevious;
                @Previous.performed += instance.OnPrevious;
                @Previous.canceled += instance.OnPrevious;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public MainActions @Main => new MainActions(this);

    // Overlay
    private readonly InputActionMap m_Overlay;
    private IOverlayActions m_OverlayActionsCallbackInterface;
    private readonly InputAction m_Overlay_Next;
    private readonly InputAction m_Overlay_Previous;
    private readonly InputAction m_Overlay_Select;
    private readonly InputAction m_Overlay_Back;
    public struct OverlayActions
    {
        private @MainNav m_Wrapper;
        public OverlayActions(@MainNav wrapper) { m_Wrapper = wrapper; }
        public InputAction @Next => m_Wrapper.m_Overlay_Next;
        public InputAction @Previous => m_Wrapper.m_Overlay_Previous;
        public InputAction @Select => m_Wrapper.m_Overlay_Select;
        public InputAction @Back => m_Wrapper.m_Overlay_Back;
        public InputActionMap Get() { return m_Wrapper.m_Overlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OverlayActions set) { return set.Get(); }
        public void SetCallbacks(IOverlayActions instance)
        {
            if (m_Wrapper.m_OverlayActionsCallbackInterface != null)
            {
                @Next.started -= m_Wrapper.m_OverlayActionsCallbackInterface.OnNext;
                @Next.performed -= m_Wrapper.m_OverlayActionsCallbackInterface.OnNext;
                @Next.canceled -= m_Wrapper.m_OverlayActionsCallbackInterface.OnNext;
                @Previous.started -= m_Wrapper.m_OverlayActionsCallbackInterface.OnPrevious;
                @Previous.performed -= m_Wrapper.m_OverlayActionsCallbackInterface.OnPrevious;
                @Previous.canceled -= m_Wrapper.m_OverlayActionsCallbackInterface.OnPrevious;
                @Select.started -= m_Wrapper.m_OverlayActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_OverlayActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_OverlayActionsCallbackInterface.OnSelect;
                @Back.started -= m_Wrapper.m_OverlayActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_OverlayActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_OverlayActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_OverlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Next.started += instance.OnNext;
                @Next.performed += instance.OnNext;
                @Next.canceled += instance.OnNext;
                @Previous.started += instance.OnPrevious;
                @Previous.performed += instance.OnPrevious;
                @Previous.canceled += instance.OnPrevious;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public OverlayActions @Overlay => new OverlayActions(this);
    public interface IMainActions
    {
        void OnNext(InputAction.CallbackContext context);
        void OnPrevious(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
    public interface IOverlayActions
    {
        void OnNext(InputAction.CallbackContext context);
        void OnPrevious(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
}
