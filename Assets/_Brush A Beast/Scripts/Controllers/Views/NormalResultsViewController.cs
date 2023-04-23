using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NormalResultsViewController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtFinalScore;
    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable(int score)
    {
        txtFinalScore.text = score.ToString();
        gameObject.SetActive(true);
    }
    
    
}
