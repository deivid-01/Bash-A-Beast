using UnityEngine;

public class PlayerWebServiceBase: MonoBehaviour
{
    protected  string URI;
    
    protected Coroutine requestCoroutine;
    
    public void Init(string uri)
    {
        URI = uri;
    }
}
