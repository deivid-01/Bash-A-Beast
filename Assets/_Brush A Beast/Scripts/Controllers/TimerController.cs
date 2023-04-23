using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private float totalSeconds;
    [SerializeField] private TextMeshProUGUI txtRemaingSeconds;
    private Coroutine _coroutineTimer;
    private float _remainingSeconds;

    public float RemainingSeconds
    {
        get => _remainingSeconds;
        set
        {
            _remainingSeconds = value;
            if (value <= 0)
                _remainingSeconds = 0;
            string numStr = _remainingSeconds.ToString("0.00");
            string[] parts = numStr.Split('.');
            txtRemaingSeconds.text = $"{int.Parse(parts[0]):00}:{int.Parse(parts[1]):00}";
        }
    }
    
    public void StartTimer(Action OnComplete)
    {
        if(_coroutineTimer!=null)
            StopCoroutine(_coroutineTimer);
        _coroutineTimer = StartCoroutine(TimerCoroutine(OnComplete));
    }
    IEnumerator TimerCoroutine(Action OnComplete)
    {
        RemainingSeconds = totalSeconds;
        while (_remainingSeconds > 0)
        {
            RemainingSeconds -= Time.deltaTime;
            yield return null;
        }
        OnComplete?.Invoke();
    }
    
}
