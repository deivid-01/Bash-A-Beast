using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "BashABeast/GameData", order = 0)]
public class GameData : ScriptableObject
{
    public Player[] TopPlayers { get; private set; }

    public Player CurrentPlayer { get; }


    private APIController _apiController;
    public void Init(APIController apicontroller)
    {
        _apiController = apicontroller;
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
    

}
