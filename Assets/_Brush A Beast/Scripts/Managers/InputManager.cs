using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action OnExecuteStartGame; 
    public void OnStartGame()
    {
        OnExecuteStartGame?.Invoke();
    }
}
