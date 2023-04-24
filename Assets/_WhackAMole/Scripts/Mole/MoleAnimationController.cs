using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleAnimationController : MonoBehaviour
{
    [SerializeField] private  Collider hitDetectionCollider;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    [ContextMenu("ShowMole")]
    public void ShowMole()
    {
        _animator.Play("Show");
    }
    [ContextMenu("HideMole")]
    public void HideMole()
    {
        _animator.Play("Hide",0,0.8f);
    }

    private void EnableDisableHitDirection()
    {
        hitDetectionCollider.enabled =  !hitDetectionCollider.enabled;
    }


    public void Stop()
    {
        _animator.Play("None");
    }
}
