using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Purchase : MonoBehaviour
{
    [SerializeField] private AdsRemover _adsRemover;
    public void OnPurchaseCompleted(Product product)
    {
        switch(product.definition.id)
        {
            case "com.serbull.removeads":
                RemoveAds();
                break;
        }
    }

    private void RemoveAds()
    {
        PlayerPrefs.SetInt("removeads", 1);
        _adsRemover.UpdateRemoveAdsButton();
    }
}
