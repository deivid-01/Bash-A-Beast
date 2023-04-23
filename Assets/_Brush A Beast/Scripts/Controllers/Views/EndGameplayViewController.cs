using UnityEngine;

public class EndGameplayViewController : MonoBehaviour
{
    [SerializeField] private NormalResultsViewController normalResultsViewController;
    [SerializeField] private  HighScoreResultsViewController highScoreResultsViewController;
    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable(int finalScore,bool newHighScore)
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
            normalResultsViewController.Enable(finalScore);
        }
    }
}
