using UnityEngine;

public class GameplayViewControler : MonoBehaviour
{
    [SerializeField] private InGameplayViewController inGameplayViewController;
    [SerializeField] private EndGameplayViewController endGameplayViewController;

    public void Init(GameData gameData)
    {
        endGameplayViewController.Init(gameData);
    }
    public void HideAllViews()
    {
        inGameplayViewController.Disable();
        endGameplayViewController.Disable();
    }

    public void ShowInGameplayView()
    {
        inGameplayViewController.Enable();
    }

    public void ShowFinalResults(bool newHighScore)
    {
        inGameplayViewController.Disable();
        endGameplayViewController.Enable(newHighScore);
    }
}
