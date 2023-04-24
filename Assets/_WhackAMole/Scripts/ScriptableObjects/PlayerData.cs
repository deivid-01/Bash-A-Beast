using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "WhackAMole/PlayerData", order = 0)]
public class PlayerData : ScriptableObject
{
    [NonSerialized] private bool _isDataLoaded;
    public Player[] TopPlayers { get; private set; }

    public Player CurrentPlayer { get; private set; }

    private int _currentPlayerRank;

    public int CurrentPlayerRank => _currentPlayerRank;
    public int CurrentPlayerScore => CurrentPlayer.Score;
    public string CurrentPlayerName => CurrentPlayer.Name;
    
    public bool IsDataLoaded => _isDataLoaded;

    private APIController _apiController;
    public void Init(APIController apicontroller)
    {
        _apiController = apicontroller;
        ResetData();
    }
    private void ResetData()
    {
        _isDataLoaded = false;
        CurrentPlayer = new Player("Player", 0);
        _currentPlayerRank = 0;
        if(TopPlayers!=null)
            Array.Clear(TopPlayers, 0, TopPlayers.Length);
    }
    public void UpdateData(Action<bool> OnComplete)
    {
        _apiController.GetPlayers(HandleLoadData);
        
        void HandleLoadData(bool success, Player[] players)
        {
            if (success)
            {
                SetTopPlayers(players);
            }

            _isDataLoaded = success;
            OnComplete?.Invoke(success);
        }

    }
    private void SetTopPlayers(Player[] players)
    {
        TopPlayers = players;
    }

    public void UpdatePlayerScore(int newScore)
    {
        CurrentPlayer.Score = newScore;
    }
    
    public void UpdatePlayerName(string playerName, Action OnComplete)
    {
            CurrentPlayer.Name = playerName;
            _apiController.CreatePlayer(CurrentPlayer,OnComplete);
    }

    public void IsCurrentScoreHighScore(Action<bool> OnComplete)
    {
        if (CurrentPlayerScore <= 0)
        {
            OnComplete?.Invoke(false);
            return;
        }
        
        _apiController.IsScoreHighScore(CurrentPlayerScore,HandleComplete);

        void HandleComplete(HighScoreValidationResponse response)
        {
            if (response.Status)
            {
                _currentPlayerRank = response.PlayerRank;
            }
            
            OnComplete?.Invoke(response.Status);
        }
    }

    private void OnDisable()
    {
        ResetData();
    }
}
