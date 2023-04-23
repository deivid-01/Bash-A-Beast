using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreFinalMsgView : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI txtFinalMsg;
    private PlayerData _playerData;

    public void Init(PlayerData playerData)
    {
        _playerData = playerData;
    }
    
    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        txtFinalMsg.text = $"Good job, <color=black><size=50>{_playerData.CurrentPlayerName}</size></color>, but don't get complacent! How much higher can you push it next time?";
    }
    
}
