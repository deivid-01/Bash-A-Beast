using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHighScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtRank;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtScore;
    public void SetData(Player playerData,int rank)
    {
        txtRank.text = rank.ToString();
        txtName.text = playerData.Name;
        txtScore.text = playerData.Score.ToString();
    }
    

}
