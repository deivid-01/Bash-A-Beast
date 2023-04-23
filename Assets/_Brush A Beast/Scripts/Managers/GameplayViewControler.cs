using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayViewControler : MonoBehaviour
{
    [SerializeField] private InGameplayViewController inGameplayViewController;
    [SerializeField] private EndGameplayViewController endGameplayViewController;

    public void HideAllViews()
    {
        inGameplayViewController.Disable();
        endGameplayViewController.Disable();
    }

    public void ShowInGameplayView()
    {
        inGameplayViewController.Enable();
    }

    public void ShowFinalResults(int finalScore,bool newHighScore)
    {
        inGameplayViewController.Disable();
        endGameplayViewController.Enable(finalScore,newHighScore);
    }
}
