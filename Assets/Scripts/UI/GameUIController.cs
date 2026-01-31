using TMPro;
using UnityEngine;

// Scene 3
public class GameUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nicknameText;

    private void Start()
    {
        nicknameText.text = UserSession.Instance.Nickname;
    }

    public void BackToLobby()
    {
        SceneLoader.Instance.LoadLobby();
    }

    public void BackToIntro()
    {
        UserSession.Instance.Logout();
        SceneLoader.Instance.LoadIntro();
    }
}

