using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginUIController : MonoBehaviour
{
    [SerializeField] TMP_InputField loginInput;
    [SerializeField] TMP_InputField passwordInput;
    [SerializeField] TextMeshProUGUI feedback;
    [SerializeField] Button startButton;

    private Coroutine loginCoroutine;

    private void Awake()
    {
        startButton.interactable = false;

        loginInput.onValueChanged.AddListener(_ => ValidateInputs());
        passwordInput.onValueChanged.AddListener(_ => ValidateInputs());
    }

    private void Start()
    {
        startButton.onClick.AddListener(OnStartClicked);
    }

    private void ValidateInputs()
    {
        bool valid =
            !string.IsNullOrWhiteSpace(loginInput.text) &&
            !string.IsNullOrWhiteSpace(passwordInput.text);

        startButton.interactable = valid;
    }

    public void OnStartClicked()
    {
        if (!startButton.interactable)
            return;

        startButton.interactable = false;

        string login = loginInput.text;
        string pass = passwordInput.text;

        if (!AuthService.Login(login, pass))
        {
            feedback.text = "Identifiants incorrects.";
            startButton.interactable = true;
            return;
        }

        UserSession.Instance.SetLogin(login);
        feedback.text = "Authentification réussie ! Connexion en cours...";

        if (loginCoroutine != null)
            StopCoroutine(loginCoroutine);

        loginCoroutine = StartCoroutine(SimulateLaunchTime(2));
    }

    IEnumerator SimulateLaunchTime(int time)
    {
        yield return new WaitForSeconds(time);
        SceneLoader.Instance.LoadLobby();
    }

    public void OnQuit() => SceneLoader.Instance.QuitGame();
}
