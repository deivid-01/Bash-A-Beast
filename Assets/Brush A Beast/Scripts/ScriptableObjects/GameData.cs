using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Brush_A_Beast.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameData", menuName = "BashABeast/GameData", order = 0)]
    public class GameData : ScriptableObject
    {
        private Player[] _topPlayers;
        
        private Player _currentPlayer;
        
        public Player[] TopPlayers => _topPlayers.ToArray();

        public Player CurrentPlayer => _currentPlayer;

        public void SetTopPlayers(Player[] players)
        {
            _topPlayers = players;
        }
        

    }
}