using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetPlayersWebService : PlayerWebServiceBase
    {
        [ContextMenu("GetPlayers")]
        public void GetPlayers(Action<bool,Player[]> OnSuccess)
        {
            ValidateAndStartRequestCoroutine(RequestPlayers(URI, HandlePlayerRawData));
                
            void HandlePlayerRawData(bool success, string rawData)
            {
                if (!success)
                {
                    OnSuccess?.Invoke(false,null);
                    return;
                }
        
                var playerResponse = JsonUtility.FromJson<PlayersResponse>(rawData);
                OnSuccess?.Invoke(true,playerResponse.Players);
            }

        }
    
        IEnumerator RequestPlayers(string uri,Action<bool,string> OnComplete)
        {
            using var webRequest = UnityWebRequest.Get(uri);
        
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogWarning("Error: " + webRequest.error);
                yield break;
            }

            string rawData = webRequest.downloadHandler.text;
          //  Debug.Log("Data Loaded");
            OnComplete?.Invoke(true,rawData);
        
        }
    }