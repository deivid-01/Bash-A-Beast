using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;


public class WebServiceHelper: MonoBehaviour
    {

        private Coroutine requestCoroutine;

        public void DoPostRequest<T,k>(string url,k data,Action<bool,T> OnComplete)
        {
            ValidateAndStartRequestCoroutine(PostRequest<T,k>(url, data, OnComplete));
        }

        public void DoGetRequest<T>(string url, Action<bool, T> OnComplete)
        {
            ValidateAndStartRequestCoroutine(GetRequest<T>(url, OnComplete));
        }
        
        private IEnumerator PostRequest<T,k>(string url,k data,Action<bool,T> OnComplete)
        {
            string dataJSON = JsonUtility.ToJson(data);
            byte[] bodyRaw = Encoding.UTF8.GetBytes(dataJSON);

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
            
                
                OnComplete?.Invoke(true,JsonUtility.FromJson<T>(rawData));
            }
        }
        
        private IEnumerator GetRequest<T>(string uri,Action<bool,T> OnComplete)
        {
            using var webRequest = UnityWebRequest.Get(uri);
        
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogWarning("Error: " + webRequest.error);
                yield break;
            }

            string rawData = webRequest.downloadHandler.text;
            var data = JsonUtility.FromJson<T>(rawData);
            OnComplete?.Invoke(true,data);
        
        }
        
        private void ValidateAndStartRequestCoroutine(IEnumerator routine)
        {
            
            if(requestCoroutine!= null)
                StopCoroutine(requestCoroutine);
            requestCoroutine=StartCoroutine(routine);
        }
    }
