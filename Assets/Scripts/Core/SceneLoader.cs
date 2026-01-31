using UnityEngine;
using UnityEngine.SceneManagement;

// Navigation uniquement
public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

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

    public void LoadIntro() => SceneManager.LoadScene("IntroScene");
    public void LoadLobby() => SceneManager.LoadScene("LobbyScene");
    public void LoadGame() => SceneManager.LoadScene("GameScene");

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

