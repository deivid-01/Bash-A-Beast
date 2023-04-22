using System;
using UnityEngine;

[Serializable]
public class PlayersResponse
{ 
    [SerializeField] private Player[] players;

    public PlayersResponse(Player[] players)
    {
        this.players = players;
    }

    public Player[] Players => players;
}
