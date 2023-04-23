using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreResultsViewController : MonoBehaviour
{
    [SerializeField] private HighScoreSaverView highScoreSaverView;
    [SerializeField] private HighScoreFinalMsgView msgView;
    private GameData _gameData;
    
    public void Init(GameData gameData)
    {
        _gameData = gameData;
        highScoreSaverView.Init(_gameData);
        msgView.Init(_gameData);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        highScoreSaverView.OnSavePlayer+=HandleSavePlayer;
        highScoreSaverView.Enable();
        msgView.Disable();
    }

    private void OnDisable()
    {
        highScoreSaverView.OnSavePlayer-=HandleSavePlayer;
    }

    private void HandleSavePlayer()
    {
        highScoreSaverView.Disable();
        msgView.Enable();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
        
    }
}
