using UnityEngine;

// Pop up menu
public class OptionsUIController : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
    }
}

