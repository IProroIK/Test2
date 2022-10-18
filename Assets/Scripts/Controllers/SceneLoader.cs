using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int _currentLevel;

    void Awake()
    {
        _currentLevel = PlayerPrefs.GetInt("LVL", 0);
        if (_currentLevel < SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("LVL", SceneManager.GetActiveScene().buildIndex);

        }
        _currentLevel = PlayerPrefs.GetInt("LVL");
        if (_currentLevel != SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(_currentLevel);
        }
    }
}
