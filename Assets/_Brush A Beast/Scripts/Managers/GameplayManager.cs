using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private MoleDetector moleDetector;
    [SerializeField] private GameplayInputController gameplayInputController;
    [SerializeField] private TimerController timerController;
    [SerializeField] private MolesController molesController;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private GameplayViewControler viewController;
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
        scoreController.Init();
        molesController.StartAllMolesBehavior();   
        timerController.StartTimer(EndGameplay);
        viewController.HideAllViews();
        viewController.ShowInGameplayView();
        gameplayInputController.OnHitMoleTriggered+=HandleHitMoleTriggered;
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

    private void ShowResults(bool isHighScore)
    {
        viewController.ShowFinalResults(isHighScore);
    }
}

  
