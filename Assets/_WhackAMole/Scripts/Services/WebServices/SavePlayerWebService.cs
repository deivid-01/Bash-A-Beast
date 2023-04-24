using System;
public class SavePlayerWebService : PlayerWebServiceBase
    {
        public SavePlayerWebService(string uri, WebServiceHelper webServiceHelper) : base(uri, webServiceHelper)
        {
        }
        public void SavePlayer(Player newPlayer,Action OnComplete)
        {
            _webServiceHelper.DoPostRequest<string,Player>(URI,newPlayer,HandlePlayerCreated);
            
            void HandlePlayerCreated(bool success, string playerCreated)
            {
                if (!success) return;
            
                OnComplete?.Invoke();
            }
        }
    }
