using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{ 
    private int _scoreByHit;
    [SerializeField] private TextMeshProUGUI txtScore;
    private int _currentScore;

    public int CurrentScore
    {
        get => _currentScore;
        set
        {
            _currentScore = value;
            txtScore.text = value.ToString();
        }
    }

    public void Init(int scoreByHit)
    {
        _scoreByHit = scoreByHit;
        CurrentScore = 0;
    }

    public void IncreaseScore()
    {
        CurrentScore+=_scoreByHit;
    }
}
