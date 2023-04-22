using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HighScoreViewController : MonoBehaviour
{
    [SerializeField] private Transform rowsContainer;
    private  PlayerHighScoreView[] playerHighScoreViews;
    
    private Player _defaultPlayer;
    
    private GameData _gameData;
    
    public void Init(GameData gameData)
    {
        _gameData = gameData;
        _defaultPlayer = new Player("--", 0);
        playerHighScoreViews = rowsContainer.GetComponentsInChildren<PlayerHighScoreView>();
       
        SetRowsData();
    }

    private void SetRowsData()
    {
        for (int i = 1; i < playerHighScoreViews.Length; i++)
        {
            var playerData = (i <= _gameData.TopPlayers.Length) ? _gameData.TopPlayers[i - 1] : _defaultPlayer;
            playerHighScoreViews[i].SetData(playerData,i);
        }
    }
}
