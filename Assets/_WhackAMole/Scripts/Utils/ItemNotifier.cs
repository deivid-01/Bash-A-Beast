
using System;
using UnityEngine;

public abstract class ItemNotifier: MonoBehaviour
{
    public event Action OnTriggered;

    protected void NotifyTrigger()
    {
        OnTriggered?.Invoke();
    }
}
