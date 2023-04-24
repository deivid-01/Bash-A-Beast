using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonNotifier : ItemNotifier
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(NotifyTrigger);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(NotifyTrigger);
    }
}
    
