using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class WinUI : MonoBehaviour
{
    [SerializeField] private Button _winButton;
    [SerializeField] private Button _retryButton;
    [SerializeField] private GameObject _winUI;
    [SerializeField] private Win _win;
    private void Awake()
    {
        _winButton.onClick.AddListener(LoadNextLevel);
        _retryButton.onClick.AddListener(ReloadLevel);
        _win.OnGetToPlanet += ActiveWinUI;
    }

    private void OnDisable()
    {
        _win.OnGetToPlanet -= ActiveWinUI;
    }
    private void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 29)
        {
            PlayerPrefs.SetInt("LVL", 6);
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void ActiveWinUI()
    {
        _winUI.gameObject.SetActive(true);
        UnityEngine.Debug.Log(SceneManager.GetActiveScene().buildIndex);

    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

