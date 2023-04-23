using UnityEngine;

    public class Singlenton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(instance);
            }
        }
    }
