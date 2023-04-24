using System;
using UnityEngine;

public class MoleController : MonoBehaviour
{
    private MoleAnimationController _moleAnimatorController;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        _moleAnimatorController = GetComponent<MoleAnimationController>();
    }
    public void GetHit()
    {
        _moleAnimatorController.HideMole();
    }

    public void StartBehavior()
    {
        _moleAnimatorController.ShowMole();
    }

    public void StopBehavior()
    {
        _moleAnimatorController.Stop();
    }
}
