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
 
    private PlayerData _playerData;
    
    public void Init(PlayerData playerData)
    {
        _playerData = playerData;
      
    }
    
    public void Enable()
    {
        gameObject.SetActive(true);
        btnSavePlayerName.interactable = true;
        playerNameInputField.interactable = true;
        
        txtFinalScore.text = _playerData.CurrentPlayer.Score.ToString();
//        print(_playerData.CurrentPlayerRank);
        txtMsg.text = $"You are now <color=black><size=50>{_playerData.CurrentPlayerRank}st</size></color> in the global rank";
        btnSavePlayerName.onClick.AddListener(SavePlayerName);
    }
    
    private void SavePlayerName()
    {
        btnSavePlayerName.interactable = false;
        playerNameInputField.interactable = false;
        _playerData.UpdatePlayerName(playerNameInputField.text,()=>OnSavePlayer?.Invoke());
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
