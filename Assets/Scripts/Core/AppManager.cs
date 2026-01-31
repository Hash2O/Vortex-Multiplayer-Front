using UnityEngine;

// Singleton global, très léger
public class AppManager : MonoBehaviour
{
    public static AppManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

