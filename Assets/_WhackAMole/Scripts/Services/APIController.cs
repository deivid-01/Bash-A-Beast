using System;
public class APIController : Singlenton<APIController>
{
    private WebServiceHelper _webServiceHelper;
    private GetPlayersWebService _getPlayersWebService;
    private SavePlayerWebService _savePlayerWebService;
    private HighScoreValidationWebService _highScoreValidationWebService;
    public void Init(string baseURL,string playersRoute,string highScoreService)
    {
        _webServiceHelper = GetComponent<WebServiceHelper>();
        _getPlayersWebService =  new GetPlayersWebService(baseURL + playersRoute,_webServiceHelper);
        _savePlayerWebService = new SavePlayerWebService(baseURL + playersRoute,_webServiceHelper);
        _highScoreValidationWebService = new HighScoreValidationWebService(baseURL+highScoreService,_webServiceHelper);
    }
    public void GetPlayers(Action<bool,Player[]> OnSuccess)
    {
        _getPlayersWebService.GetPlayers(OnSuccess);
    }
    public void CreatePlayer(Player newPlayer,Action OnComplete)
    {
        _savePlayerWebService.SavePlayer(newPlayer,OnComplete);
    }
    public void IsScoreHighScore(int score,Action<HighScoreValidationResponse>OnComplete)
    {
      
        _highScoreValidationWebService.ValidateScore(score, HandleComplete);
        void HandleComplete(bool success,HighScoreValidationResponse highScoreResponse)
        {
            if (!success) return;
            OnComplete?.Invoke(highScoreResponse);
        }
    }
}
