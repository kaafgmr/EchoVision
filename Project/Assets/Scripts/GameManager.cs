using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject DialogTextUI;
    [SerializeField] public Image DialogBackgroundImage;
    [SerializeField] public TextMeshProUGUI Dialogtext;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DialogTextUI.SetActive(false);
    }
}
