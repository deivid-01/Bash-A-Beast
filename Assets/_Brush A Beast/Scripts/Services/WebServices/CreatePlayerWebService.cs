using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class CreatePlayerWebService : PlayerWebServiceBase
    {
        public void AddPlayer(Player newPlayer)
        {
            ValidateAndStartRequestCoroutine(AddPlayerRequest(newPlayer, URI, HandlePlayerCreated));
        }
        
        IEnumerator AddPlayerRequest(Player playerToAdd, string url, Action<bool, string> OnComplete)
        {

            string playerJson = JsonUtility.ToJson(playerToAdd);
            byte[] bodyRaw = Encoding.UTF8.GetBytes(playerJson);

            using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
            {
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("POST request failed: " + request.error);
                    yield break;
                }

                string rawData = request.downloadHandler.text;
                Debug.Log("POST response: " + rawData);
            }
        }

    
        private void HandlePlayerCreated(bool success, string rawData)
        {
            if (!success) return;
        
            //var playerResponse = JsonUtility.FromJson<PlayersResponse>(rawData);
            // players = playerResponse.Players;
        }
    }
