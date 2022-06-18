using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WinUI : MonoBehaviour
{
    [SerializeField] private Button _winButton;
    [SerializeField] private Button _retryButton;
    [SerializeField] private Win _win;
    private void Awake()
    {
        _winButton.onClick.AddListener(LoadNextLevel);
        _retryButton.onClick.AddListener(ReloadLevel);
        _winButton.gameObject.SetActive(false);
        _retryButton.gameObject.SetActive(false);
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
        _winButton.gameObject.SetActive(true);
        _retryButton.gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

