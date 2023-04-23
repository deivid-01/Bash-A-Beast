using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayInputController : MonoBehaviour
{
    public event Action<Vector2> OnHitMoleTriggered;
    
    PlayerInput _playerInput;
        
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnHitMole()
    {
        Vector2 mousePosition=_playerInput.actions["PointerPosition"].ReadValue<Vector2>();
        OnHitMoleTriggered?.Invoke(mousePosition);
    }
    
}
