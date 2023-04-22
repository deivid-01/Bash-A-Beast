using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class APIController : MonoBehaviour
{
    [SerializeField] private string BASE_API_URL;
    [SerializeField] private string PLAYERS_ROUTE;

    private Coroutine _getPlayerCoroutine;
    private Coroutine _addPlayerCoroutine;
    public Player  playerToAdd;

    [ContextMenu("GetPlayers")]
    public void GetPlayers(Action<bool,Player[]> OnSuccess)
    {
        if(_getPlayerCoroutine!= null)
            StopCoroutine(_getPlayerCoroutine);
        _getPlayerCoroutine=StartCoroutine(RequestPlayers(BASE_API_URL+PLAYERS_ROUTE,HandlePlayerRawData));
        
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
        Debug.Log("Data Loaded");
        OnComplete?.Invoke(true,rawData);
        
    }
    
    [ContextMenu("AddPlayer")]
    public void AddPlayer()
    {
        if(_addPlayerCoroutine!= null)
            StopCoroutine(_addPlayerCoroutine);
        _addPlayerCoroutine=StartCoroutine(AddPlayerRequest(playerToAdd,BASE_API_URL+PLAYERS_ROUTE,HandlePlayerCreated));

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
