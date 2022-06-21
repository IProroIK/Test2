using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoseUI : MonoBehaviour
{
    [SerializeField] private Button _retryButton;
    [SerializeField] private DeathZone _deathZone;
    [SerializeField] private GameObject _loseUI;
    private void Awake()
    {
        _deathZone.OnDeth += ActiveLoseUI;
        _retryButton.onClick.AddListener(ReloadLevel);
    }

    private void OnDisable()
    {
        _deathZone.OnDeth -= ActiveLoseUI;
    }

    private void ActiveLoseUI()
    {
        _loseUI.SetActive(true);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
