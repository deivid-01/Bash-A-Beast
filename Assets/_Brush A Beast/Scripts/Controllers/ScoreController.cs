using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private int scoreByHit;
    [SerializeField] private TextMeshProUGUI txtScore;
    private int currentScore;

    public int CurrentScore
    {
        get => currentScore;
        set
        {
            currentScore = value;
            txtScore.text = value.ToString();
        }
    }

    public void Init()
    {
        CurrentScore = 0;
    }

    public void IncreaseScore()
    {
        CurrentScore+=scoreByHit;
    }
}
