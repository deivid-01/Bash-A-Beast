using UnityEngine;

public class GameplayViewControler : MonoBehaviour
{
    [SerializeField] private InGameplayViewController inGameplayViewController;
    [SerializeField] private EndGameplayViewController endGameplayViewController;

    public void Init(PlayerData playerData)
    {
        endGameplayViewController.Init(playerData);
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
