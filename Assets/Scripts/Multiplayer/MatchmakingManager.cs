using UnityEngine;

public class MatchmakingManager : MonoBehaviour
{
    public static MatchmakingManager Instance;

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

    public void HostGame()
    {
        Debug.Log("Hosting...");
        SceneLoader.Instance.LoadGame();
    }

    public void JoinGame()
    {
        Debug.Log("Joining...");
        SceneLoader.Instance.LoadGame();
    }
}

