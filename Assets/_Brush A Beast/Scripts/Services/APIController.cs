using System;
using UnityEngine;


public class APIController : Singlenton<APIController>
{
    [SerializeField] private string BASE_API_URL;
    [SerializeField] private string PLAYERS_ROUTE;
    [SerializeField] private string HIGHSCORE_VALIDATION;
    
    [SerializeField] private WebServiceHelper webServiceHelper;
    private GetPlayersWebService _getPlayersWebService;
    private SavePlayerWebService _savePlayerWebService;
    private HighScoreValidationWebService _highScoreValidationWebService;
    
    
    public void Init()
    {
        _getPlayersWebService =  new GetPlayersWebService(BASE_API_URL + PLAYERS_ROUTE,webServiceHelper);
        _savePlayerWebService = new SavePlayerWebService(BASE_API_URL + PLAYERS_ROUTE,webServiceHelper);
        _highScoreValidationWebService = new HighScoreValidationWebService(BASE_API_URL+HIGHSCORE_VALIDATION,webServiceHelper);
    }
    public void GetPlayers(Action<bool,Player[]> OnSuccess)
    {
        _getPlayersWebService.GetPlayers(OnSuccess);
    }
    
    public void AddPlayer(Player newPlayer,Action OnComplete)
    {
        _savePlayerWebService.SavePlayer(newPlayer,OnComplete);
    }

    [ContextMenu("IsScoreHIghScoreTest")]
    public void IsScoreHighScoreTest()
    {
        IsScoreHighScore(300, null);
    }
    public void IsScoreHighScore(int score,Action<HighScoreValidationResponse>OnComplete)
    {
        _highScoreValidationWebService = new HighScoreValidationWebService(BASE_API_URL+HIGHSCORE_VALIDATION,webServiceHelper);
        _highScoreValidationWebService.ValidateScore(score, HandleComplete);
        void HandleComplete(bool success,HighScoreValidationResponse highScoreResponse)
        {
            if (!success) return;
            OnComplete?.Invoke(highScoreResponse);
        }
    }
    
}
