using UnityEngine;

// Stockage de la session en mémoire
public class UserSession : MonoBehaviour
{
    public static UserSession Instance;

    public string Login { get; private set; }
    public string Nickname { get; private set; }
    public bool IsAuthenticated { get; private set; }

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

    public void SetLogin(string login)
    {
        Login = login;
        IsAuthenticated = true;
    }

    public void SetNickname(string nickname)
    {
        Nickname = nickname;
    }

    public void Logout()
    {
        Login = "";
        Nickname = "";
        IsAuthenticated = false;
    }
}

