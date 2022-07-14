using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    [SerializeField] private Transform _shop;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        _shop.gameObject.SetActive(false);
        _shopButton.onClick.AddListener(OppenShop);
        _closeButton.onClick.AddListener(CloseShop);
    }
    private void OppenShop()
    {
        _shop.gameObject.SetActive(true);
    }

    private void CloseShop()
    {
        _shop.gameObject.SetActive(false);
    }
}
