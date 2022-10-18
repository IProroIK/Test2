using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AdsRemover : MonoBehaviour
{
    [SerializeField] private GameObject _removeAdsButton;
    [SerializeField] private GameObject _removeAdsText;
    private void Start()
    {
        UpdateRemoveAdsButton();
    }
    public void UpdateRemoveAdsButton()
    {
        bool removeAds = PlayerPrefs.GetInt("removeads") == 1;
        if (_removeAdsButton == null && _removeAdsText == null)
        {
            _removeAdsButton.SetActive(!removeAds);
            _removeAdsText.SetActive(removeAds);
            Destroy(this.gameObject);
        }
    }
}
