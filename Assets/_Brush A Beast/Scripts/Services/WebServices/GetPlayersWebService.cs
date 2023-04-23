using System;

public class GetPlayersWebService : PlayerWebServiceBase
    {
        public GetPlayersWebService(string uri, WebServiceHelper webServiceHelper) : base(uri, webServiceHelper)
        {
        }
        public void GetPlayers(Action<bool,Player[]> OnSuccess)
        {
            _webServiceHelper.DoGetRequest<PlayersResponse>(URI,HandlePlayerRawData);
            
            void HandlePlayerRawData(bool success, PlayersResponse data)
            {
                if (!success)
                {
                    OnSuccess?.Invoke(false,null);
                    return;
                }
                OnSuccess?.Invoke(true,data.Players);
            }

        }

        
    }