using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    
    [SerializeField] private TextMeshProUGUI coinsCounter;
    [SerializeField] private Button menuButton;

    private int _coinsPicked;

    private void Start()
    {
        menuButton.onClick.AddListener(ExitToMainMenu);
    }

    public void IncrementCoinCounter()
    {
        _coinsPicked++;
        coinsCounter.SetText(_coinsPicked.ToString());
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Scene_1");
    }
}
