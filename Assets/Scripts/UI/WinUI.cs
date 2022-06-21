using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ActiveWinUI()
    {
        _winUI.gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

