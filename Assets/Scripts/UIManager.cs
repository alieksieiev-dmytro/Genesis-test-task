using System;
using System.Collections;
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
    [SerializeField] private FadeUIAnimation loadingScreen;
    
    private int _coinsPicked;

    private void Start()
    {
        loadingScreen.FadeOut();
        loadingScreen.transform.SetAsFirstSibling();
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
    
    public void ExitToMainMenu(float delay)
    {
        StartCoroutine(ExitToMainMenu_Coroutine(1f));
    }

    private IEnumerator ExitToMainMenu_Coroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        ExitToMainMenu();
    }
}
