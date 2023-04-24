using System;

public class HighScoreValidationWebService : PlayerWebServiceBase
{
    public HighScoreValidationWebService(string uri, WebServiceHelper webServiceHelper) : base(uri, webServiceHelper)
    {
    }
    public void ValidateScore(int score, Action<bool,HighScoreValidationResponse> OnComplete)
    {
        _webServiceHelper.DoPostRequest(URI,new HighScoreValidationRequest(score),OnComplete);
    }
}
