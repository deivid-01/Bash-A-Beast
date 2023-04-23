using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private MoleDetector moleDetector;
    [SerializeField] private GameplayInputController gameplayInputController;
    [SerializeField] private TimerController timerController;
    [SerializeField] private MolesController molesController;
    [SerializeField] private ScoreController scoreController;
    void Start()
    {
        Init();
        StartGameplay();
    }

    private void Init()
    {
        cameraController.Init();
        moleDetector.Init(cameraController);
    }

    private void StartGameplay()
    {
        scoreController.Init();
        molesController.StartAllMolesBehavior();   
        timerController.StartTimer(EndGameplay);
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
    }
}

  
