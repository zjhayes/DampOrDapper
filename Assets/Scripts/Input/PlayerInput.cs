//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Input/PlayerInput.inputactions
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

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""c556b326-ccf9-4ac9-9281-3b354d3537f7"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2f4e08c1-7722-4f6d-9ae7-6472cc1e301b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""806abe2a-ba24-40ba-9e75-29dcb39d29ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""5862a02e-3059-48da-9956-21fb3ff2d2f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shield"",
                    ""type"": ""Button"",
                    ""id"": ""8ede2881-91df-4554-b6a8-dd67dcfac23c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""KeyboardMovement"",
                    ""id"": ""fcf73642-5b75-4313-9da5-10926847c54e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b32591bf-06a0-4a25-a12f-468b1a6c9dae"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b0ff4d99-06d9-42b7-8528-839db12f3ab0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8a3b33f3-e4c1-47b1-a56f-b6c474b73178"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb180a2b-cf15-4b96-b6f9-f89447b86c10"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4bece3e-7832-425d-973d-6c75dbf314de"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Weather"",
            ""id"": ""c6a7f60d-c809-4a4f-a133-188c468643ba"",
            ""actions"": [
                {
                    ""name"": ""Whirlwind"",
                    ""type"": ""Button"",
                    ""id"": ""810a5169-d6f6-4549-9e67-1ae6d9921d8c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d0708040-9d5a-4db5-ac31-1b09221e9092"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Whirlwind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Character
        m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
        m_Character_Movement = m_Character.FindAction("Movement", throwIfNotFound: true);
        m_Character_Run = m_Character.FindAction("Run", throwIfNotFound: true);
        m_Character_Attack = m_Character.FindAction("Attack", throwIfNotFound: true);
        m_Character_Shield = m_Character.FindAction("Shield", throwIfNotFound: true);
        // Weather
        m_Weather = asset.FindActionMap("Weather", throwIfNotFound: true);
        m_Weather_Whirlwind = m_Weather.FindAction("Whirlwind", throwIfNotFound: true);
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

    // Character
    private readonly InputActionMap m_Character;
    private ICharacterActions m_CharacterActionsCallbackInterface;
    private readonly InputAction m_Character_Movement;
    private readonly InputAction m_Character_Run;
    private readonly InputAction m_Character_Attack;
    private readonly InputAction m_Character_Shield;
    public struct CharacterActions
    {
        private @PlayerInput m_Wrapper;
        public CharacterActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Character_Movement;
        public InputAction @Run => m_Wrapper.m_Character_Run;
        public InputAction @Attack => m_Wrapper.m_Character_Attack;
        public InputAction @Shield => m_Wrapper.m_Character_Shield;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                @Run.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRun;
                @Attack.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAttack;
                @Shield.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShield;
                @Shield.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShield;
                @Shield.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShield;
            }
            m_Wrapper.m_CharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Shield.started += instance.OnShield;
                @Shield.performed += instance.OnShield;
                @Shield.canceled += instance.OnShield;
            }
        }
    }
    public CharacterActions @Character => new CharacterActions(this);

    // Weather
    private readonly InputActionMap m_Weather;
    private IWeatherActions m_WeatherActionsCallbackInterface;
    private readonly InputAction m_Weather_Whirlwind;
    public struct WeatherActions
    {
        private @PlayerInput m_Wrapper;
        public WeatherActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Whirlwind => m_Wrapper.m_Weather_Whirlwind;
        public InputActionMap Get() { return m_Wrapper.m_Weather; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeatherActions set) { return set.Get(); }
        public void SetCallbacks(IWeatherActions instance)
        {
            if (m_Wrapper.m_WeatherActionsCallbackInterface != null)
            {
                @Whirlwind.started -= m_Wrapper.m_WeatherActionsCallbackInterface.OnWhirlwind;
                @Whirlwind.performed -= m_Wrapper.m_WeatherActionsCallbackInterface.OnWhirlwind;
                @Whirlwind.canceled -= m_Wrapper.m_WeatherActionsCallbackInterface.OnWhirlwind;
            }
            m_Wrapper.m_WeatherActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Whirlwind.started += instance.OnWhirlwind;
                @Whirlwind.performed += instance.OnWhirlwind;
                @Whirlwind.canceled += instance.OnWhirlwind;
            }
        }
    }
    public WeatherActions @Weather => new WeatherActions(this);
    public interface ICharacterActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
    }
    public interface IWeatherActions
    {
        void OnWhirlwind(InputAction.CallbackContext context);
    }
}
