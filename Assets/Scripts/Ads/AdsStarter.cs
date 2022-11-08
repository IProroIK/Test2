using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsStarter : MonoBehaviour
{
    [SerializeField] private InterstitialAds _ads;
    [SerializeField] private DeathZone _deathZone;
    [SerializeField] private Win _win;

    private void Start()
    {
        _win.OnGetToPlanet += _ads.ShowAd;
        _deathZone.OnDeth += DethAdsShow;
    }

    private void OnDisable()
    {
        _win.OnGetToPlanet -= _ads.ShowAd;
        _deathZone.OnDeth -= DethAdsShow;
    }

    private void DethAdsShow()
    {
        int a = Random.Range(1, 4);
        if(a == 3)
        {
            _ads.ShowAd();
        }

    }

}
