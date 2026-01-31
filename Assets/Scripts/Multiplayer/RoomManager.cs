using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public void AddPlayer(string nickname)
    {
        Debug.Log($"Player joined: {nickname}");
    }
}

