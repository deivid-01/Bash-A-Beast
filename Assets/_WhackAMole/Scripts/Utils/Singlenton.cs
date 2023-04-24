using UnityEngine;

public class Singlenton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;
    private void Awake()
    {
        if (Instance != null)
        {
           Destroy(this);
            return;
        }
        Instance = this as T;
        DontDestroyOnLoad(Instance);
    }
}
