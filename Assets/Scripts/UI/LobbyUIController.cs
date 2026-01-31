using TMPro;
using UnityEngine;

// Scene 2
public class LobbyUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI welcomeText;
    [SerializeField] TMP_InputField nicknameInput;

    private void Start()
    {
        welcomeText.text = $"Bienvenue {UserSession.Instance.Login}";
    }

    public void OnNicknameConfirm()
    {
        UserSession.Instance.SetNickname(nicknameInput.text);
    }

    public void OnHost()
    {
        MatchmakingManager.Instance.HostGame();
    }

    public void OnJoin()
    {
        MatchmakingManager.Instance.JoinGame();
    }

    public void OnBack()
    {
        SceneLoader.Instance.LoadIntro();
    }
}

