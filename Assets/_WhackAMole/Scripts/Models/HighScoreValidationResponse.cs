
using System;
using UnityEngine;

[Serializable]
public class HighScoreValidationResponse
{
    [SerializeField] private bool status;
    [SerializeField] private int rank;

    public bool Status => status;

    public int PlayerRank => rank;

}
[Serializable]
public class HighScoreValidationRequest
{
    [SerializeField] private int score;

    public HighScoreValidationRequest(int score)
    {
        this.score = score;
    }
}
