using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NormalResultsViewController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtFinalScore;

    private GameData _gameData;
    public void Init(GameData gameData)
    {
        _gameData = gameData;
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        txtFinalScore.text = _gameData.CurrentPlayerScore.ToString();
        gameObject.SetActive(true);
    }


   
}
