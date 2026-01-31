using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Login")]
    [SerializeField] private TMP_InputField loginInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private Button startButton;
    [SerializeField] private TextMeshProUGUI feedbackText;

    [Header("Données utilisateur")]
    public string Login { get; private set; }
    public string Password { get; private set; }

    private void Awake()
    {
        // Singleton basique
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Sécurité: s'assurer que le champ mot de passe est bien masqué
        if (passwordInput != null)
        {
            passwordInput.contentType = (TMP_InputField.ContentType)InputField.ContentType.Password;
            passwordInput.ForceLabelUpdate();
        }
    }

    private void Start()
    {
        // On désactive le bouton au départ
        if (startButton != null)
            startButton.interactable = false;

        // On écoute les changements sur les InputField
        if (loginInput != null)
            loginInput.onValueChanged.AddListener(_ => CheckCanStart());

        if (passwordInput != null)
            passwordInput.onValueChanged.AddListener(_ => CheckCanStart());

        if (startButton != null)
            startButton.onClick.AddListener(OnStartClicked);
    }

    private void CheckCanStart()
    {
        bool hasLogin = loginInput != null && !string.IsNullOrWhiteSpace(loginInput.text);
        bool hasPassword = passwordInput != null && !string.IsNullOrWhiteSpace(passwordInput.text);

        if (startButton != null)
            startButton.interactable = hasLogin && hasPassword;
    }

    private void OnStartClicked()
    {
        // On stocke les valeurs dans les propriétés publiques
        Login = loginInput != null ? loginInput.text : string.Empty;
        Password = passwordInput != null ? passwordInput.text : string.Empty;

        // Exemple de "vérification" locale ultra simple
        if (Login == "user" && Password == "1234")
        {
            if (feedbackText != null)
                feedbackText.text = $"Connexion réussie, chargement en cours !";

            Debug.Log("Login OK");
            StartCoroutine(nameof(LoadLobbyScene),3);
        }
        else
        {
            if (feedbackText != null)
                feedbackText.text = "Identifiants incorrects.";
            Debug.Log("Login KO");
        }
    }

    IEnumerator LoadLobbyScene(int time)
    {
        // Simuler le temps d'accès à un serveur distant
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("LobbyScene");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void LoadScene(int index)
    {
        {
            SceneManager.LoadScene(index);
        }
    }

    public void LoadPreviousScene()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }
}

