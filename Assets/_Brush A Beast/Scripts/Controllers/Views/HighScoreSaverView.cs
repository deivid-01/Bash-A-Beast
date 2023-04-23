using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class HighScoreSaverView : MonoBehaviour
{
    public event Action OnSavePlayer;
    [SerializeField] private TextMeshProUGUI txtFinalScore;
    [SerializeField] private TMP_InputField playerNameInputField;
    [SerializeField] private TextMeshProUGUI txtMsg;
   [SerializeField] private Button btnSavePlayerName;
 
    private GameData _gameData;
    
    public void Init(GameData gameData)
    {
        _gameData = gameData;
      
    }
    
    public void Enable()
    {
        gameObject.SetActive(true);
        
        txtFinalScore.text = _gameData.CurrentPlayer.Score.ToString();
        txtMsg.text = $"You are now <color=black><size=50>{_gameData.CurrentPlayerRank}st</size></color> in the global rank";
        btnSavePlayerName.onClick.AddListener(SavePlayerName);
    }
    
    private void SavePlayerName()
    {
        _gameData.UpdatePlayerName(playerNameInputField.text);
        OnSavePlayer?.Invoke();
  
    }

    private void OnDisable()
    {
        btnSavePlayerName.onClick.RemoveListener(SavePlayerName);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

  
}
