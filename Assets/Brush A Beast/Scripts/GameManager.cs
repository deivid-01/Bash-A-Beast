using System;
using Brush_A_Beast.Scripts.ScriptableObjects;
using UnityEngine;

namespace Brush_A_Beast.Scripts
{
    public class GameManager : MonoBehaviour
    {
        
        [SerializeField] private APIController apiController;
        [SerializeField] private GameData gameData;

        [ContextMenu("StartGame")]
        private void StartGame()
        {
            apiController.GetPlayers(HandleLoadData);
            
            void HandleLoadData(bool success, Player[] players)
            {
                if (!success) return;
                
                gameData.SetTopPlayers(players);
            }
            
        }

    }
}