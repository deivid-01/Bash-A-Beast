using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreFinalMsgView : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI txtFinalMsg;
    private GameData _gameData;

    public void Init(GameData gameData)
    {
        _gameData = gameData;
    }
    
    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        txtFinalMsg.text = $"Good job, <color=black><size=50>{_gameData.CurrentPlayerName}</size></color>, but don't get complacent! How much higher can you push it next time?";
    }
    
}
