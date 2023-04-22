using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private APIController apiController;
    [SerializeField] private GameData gameData;
    [SerializeField] private HighScoreViewController highScoreViewController;
    [SerializeField] private InputManager inputManager;
    
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        apiController.Init();

        gameData.Init(apiController);
        gameData.UpdateData(DataLoaded);

        void DataLoaded(bool success)
        {
            if (!success) return;
            StartMainMenu();
        } 
    }
    private void StartMainMenu()
    {
        highScoreViewController.Init(gameData);
        inputManager.OnExecuteStartGame += StartGame;
    }

    private void StartGame()
    {
        inputManager.OnExecuteStartGame -= StartGame;
        SceneManager.LoadScene("Gameplay");
    }
}
