using Unity.VisualScripting;
using UnityEngine;

public class EndGameplayViewController : MonoBehaviour
{
   
    [SerializeField] private NormalResultsViewController normalResultsViewController;
    [SerializeField] private  HighScoreResultsViewController highScoreResultsViewController;

    public void Init(GameData gameData)
    {
        normalResultsViewController.Init(gameData);
        highScoreResultsViewController.Init(gameData);
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable(bool newHighScore)
    {
        gameObject.SetActive(true);

        if (newHighScore)
        {
            normalResultsViewController.Disable();
            highScoreResultsViewController.Enable();
        }
        else
        {
            highScoreResultsViewController.Disable();
            normalResultsViewController.Enable();
        }
    }
}
