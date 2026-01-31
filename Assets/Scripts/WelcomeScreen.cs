using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WelcomeScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI welcomeText;

    private void Start()
    {
        if (welcomeText == null) return;

        string login = GameManager.Instance != null ? GameManager.Instance.Login : "inconnu";

        welcomeText.text = $"Bonjour et bienvenue, {login}";
    }

    public void ReturnToIntroScene()
    {
        GameManager.Instance.LoadScene(0);
    }
}

