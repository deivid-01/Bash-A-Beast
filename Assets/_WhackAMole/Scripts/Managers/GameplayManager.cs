using System.Runtime.CompilerServices;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private PlayerData playerData;
    [Space]
    [SerializeField] private CameraController cameraController;
    [SerializeField] private MoleDetector moleDetector;
    [SerializeField] private GameplayInputController gameplayInputController;
    [SerializeField] private TimerController timerController;
    [SerializeField] private MolesController molesController;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private GameplayViewControler viewController;
    [Space]
    [Header("Notifiers")]
    [SerializeField] private ItemNotifier[] restartGameNotifier;
    [SerializeField] private ItemNotifier[] goMainMenuNotifier;
    void Start()
    {
        Init();
        StartGameplay();
    }

    private void Init()
    {
        cameraController.Init();
        moleDetector.Init(cameraController);
        viewController.Init(playerData);
    }

    private void StartGameplay()
    {
        scoreController.Init(gameConfig.PointsByHit);
        timerController.Init(gameConfig.RoundDurationInSeconds);
        molesController.StartAllMolesBehavior();   
        timerController.StartTimer(EndGameplay);
        viewController.HideAllViews();
        viewController.ShowInGameplayView();
        gameplayInputController.OnHitMoleTriggered+=HandleHitMoleTriggered;

        foreach (var notifier in restartGameNotifier)
        {
            notifier.OnTriggered += RestartGame;
        }
        
        foreach (var notifier in goMainMenuNotifier)
        {
            notifier.OnTriggered += GoToMainMenu;
        }
    }
    
    private void HandleHitMoleTriggered(Vector2 mousePosition)
    {
        moleDetector.TryDoRaycast(mousePosition,HandleOnHitMole);
    }
    private void HandleOnHitMole()
    {
        scoreController.IncreaseScore();
    }
    private void EndGameplay()
    {
        molesController.StopAllMolesBehavior();
        gameplayInputController.OnHitMoleTriggered-=HandleHitMoleTriggered;
        playerData.UpdatePlayerScore(scoreController.CurrentScore);
        
        playerData.IsCurrentScoreHighScore(ShowResults);
    }

    private void OnDisable()
    {
        gameplayInputController.OnHitMoleTriggered-=HandleHitMoleTriggered;
        
        foreach (var notifier in restartGameNotifier)
        {
            notifier.OnTriggered -= RestartGame;
        }
        
        foreach (var notifier in goMainMenuNotifier)
        {
            notifier.OnTriggered -= GoToMainMenu;
        }
    }

    private void ShowResults(bool isHighScore)
    {
        viewController.ShowFinalResults(isHighScore);
    }
    
    private void RestartGame()
    {
        foreach (var notifier in restartGameNotifier)
        {
            notifier.OnTriggered -= RestartGame;
        }
        gameConfig.LoadCurrentScene();
    }
    private void GoToMainMenu()
    {
        foreach (var notifier in goMainMenuNotifier)
        {
            notifier.OnTriggered -= GoToMainMenu;
        }
        gameConfig.LoadManinMenu();
    }
}

  
