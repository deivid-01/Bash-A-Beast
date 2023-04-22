using System.Collections;
using UnityEngine;

public class PlayerWebServiceBase: MonoBehaviour
{
    protected  string URI;

    private Coroutine requestCoroutine;
    public void Init(string uri)
    {
        URI = uri;
    }

    protected void ValidateAndStartRequestCoroutine(IEnumerator routine)
    {
        if(requestCoroutine!= null)
            StopCoroutine(requestCoroutine);
        requestCoroutine=StartCoroutine(routine);
    }
}
