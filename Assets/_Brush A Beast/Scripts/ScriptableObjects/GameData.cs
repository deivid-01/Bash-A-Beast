using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "BashABeast/GameData", order = 0)]
public class GameData : ScriptableObject
{
    public Player[] TopPlayers { get; private set; }

    public Player CurrentPlayer { get; private set; }

    private int _currentPlayerRank;

    public int CurrentPlayerRank => _currentPlayerRank;

    public int CurrentPlayerScore => CurrentPlayer.Score;
    public string CurrentPlayerName => CurrentPlayer.Name;


    private APIController _apiController;
    public void Init(APIController apicontroller)
    {
        _apiController = apicontroller;
        CurrentPlayer = new Player("Player", 0);
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


    public void UpdatePlayerName(string playerName)
    {
            CurrentPlayer.Name = playerName;
    }
}
