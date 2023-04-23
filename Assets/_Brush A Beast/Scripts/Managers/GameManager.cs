using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private APIController apiController;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private HighScoreViewController highScoreViewController;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject loadingCanvas;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        apiController.Init();

        playerData.Init(apiController);
        playerData.UpdateData(DataLoaded);

        void DataLoaded(bool success)
        {
            if (!success) return;
            StartMainMenu();
        } 
    }
    private void StartMainMenu()
    {
        loadingCanvas.gameObject.SetActive(false);
        highScoreViewController.Init(playerData);
        inputManager.OnExecuteStartGame += StartGame;
    }

    private void StartGame()
    {
        inputManager.OnExecuteStartGame -= StartGame;
        SceneManager.LoadScene("Gameplay");
    }
}
