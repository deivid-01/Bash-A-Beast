using System;
using UnityEngine;
public class MoleAnimationController : MonoBehaviour
{
    public event Action OnHideShow; 
    private Animator _animator;

    public void Init()
    {
        _animator = GetComponent<Animator>();
    }
    public void ShowMole() => _animator.Play("Show");

    public void HideMole() => _animator.Play("Hide",0,0.8f);

    private void NotifyOnHideShow() => OnHideShow?.Invoke();

    public void Stop() => _animator.Play("None");
}
