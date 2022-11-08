using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Shop : MonoBehaviour
{
    public event Action onBuy;
    public event Action inShop;
    public event Action closeShop;


    private const float distanceUp = 40;
    private const int damageUp = 1;
    private const float skinCost = 50;
    [SerializeField] private Transform _shop;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _jumpUpgrade;
    [SerializeField] private Button _weaponUpgrade;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private TextMeshProUGUI _jumpUpgradeCostText;
    [SerializeField] private float _jumpUpgradeCost = 20;
    [SerializeField] private float _weaponUpgradeCost = 20;
    [SerializeField] private TextMeshProUGUI _weaponUpgradeCostText;
    [SerializeField] private GameObject _currentSkin;
    [SerializeField] private List<GameObject> _skins;
    [SerializeField] private List<Button> _buyButtons;
    [SerializeField] private List<Button> _chooseButton;

    private int _currentSkinIndex;
    private bool _skinBought;
    private List<int> _skinIndexBought = new List<int>();
    private void Awake()
    {
        _shop.gameObject.SetActive(false);
        _shopButton.onClick.AddListener(OppenShop);
        _closeButton.onClick.AddListener(CloseShop);
        _jumpUpgrade.onClick.AddListener(JumpDistanceBuy);
        _weaponUpgrade.onClick.AddListener(WeaponDamageBuy);


    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("JumpUpgradeCost") || PlayerPrefs.HasKey("CurrentSkinIndex"))
        {
            LoadData();

        }
        else
        {
            Save();
        }
        UpdateStartSkin();
    }
    private void OppenShop()
    {
        _shop.gameObject.SetActive(true);
        inShop?.Invoke();
        LoadData();
        UpdateShopButtons();
    }

    private void CloseShop()
    {
        _shop.gameObject.SetActive(false);
        closeShop?.Invoke();
        Save();
    }

    public void JumpDistanceBuy()
    {
        if (_playerInfo.Buy((int)Mathf.Round(_jumpUpgradeCost)))
        {
            _playerInfo.MaxJumpDistanceUp(distanceUp);
            _jumpUpgradeCost *= 1.2f;
            _jumpUpgradeCostText.text = Mathf.Ceil(_jumpUpgradeCost).ToString() + " Gems";
            onBuy?.Invoke();
        }
    }
    public void WeaponDamageBuy()
    {
        if (_playerInfo.Buy((int)Mathf.Round(_weaponUpgradeCost)))
        {
            _playerInfo.DamageUp(damageUp);
            _weaponUpgradeCost *= 1.2f;
            _weaponUpgradeCostText.text = Mathf.Ceil(_weaponUpgradeCost).ToString() + " Gems";
            onBuy?.Invoke();
        }
    }

    /*public void UpgradeBuy(float upgradeCost, float upgradeValue, TextMeshProUGUI upgradeCostText)
    {
        if (_playerInfo.BuyUpgrade((int)Mathf.Round(upgradeCost)))
        {
            _playerInfo.DamageUp(upgradeValue); // two methods copy cods, some way to fix it but how to use 2 different methods from PlayerInfo script????
            upgradeCost *= 1.2f;
            upgradeCostText.text = Mathf.Ceil(upgradeCost).ToString() + " Gems";
            onBuy?.Invoke();
        }
    }*/

    public void SkinChange(int skinIndex)
    {
        _currentSkin.SetActive(false);
        _skins[skinIndex].SetActive(true);
        _currentSkin = _skins[skinIndex];
        _currentSkinIndex = skinIndex;
    }

    public void SkinBuy(Button chooseButton)
    {
        if(_playerInfo.Buy((int)Mathf.Round(skinCost)))
        {
            chooseButton.gameObject.SetActive(true);
            _skinBought = true;
            onBuy?.Invoke();
        }
    }

    public void HideButton(Button buy)
    {
        for(int i = 0; i < _skinIndexBought.Count; i++)
        {
            for(int j = 0; j < _skins.Count; j++)
            {
                if(_skinIndexBought[i] == j)
                {
                    buy.gameObject.SetActive(false);
                }
            }
        }
        if (_skinBought)
        {
            buy.gameObject.SetActive(false);
        }
    }

    public void SkinBoughtIndex(int skinID)
    {
        _skinIndexBought.Add(skinID);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("JumpUpgradeCost", _jumpUpgradeCost);
        PlayerPrefs.SetFloat("WeaponUpgradeCost", _weaponUpgradeCost);
        PlayerPrefs.SetInt("CurrentSkinIndex", _currentSkinIndex);
        for(int i = 0; i < _skinIndexBought.Count; i++)
        {
            PlayerPrefs.SetInt("SkinIndex" + i, _skinIndexBought[i]);
        }
        PlayerPrefs.SetInt("Amount", _skinIndexBought.Count);
    }

    private void LoadData()
    {
        _jumpUpgradeCost = PlayerPrefs.GetFloat("JumpUpgradeCost");
        _weaponUpgradeCost = PlayerPrefs.GetFloat("WeaponUpgradeCost");
        _currentSkinIndex = PlayerPrefs.GetInt("CurrentSkinIndex");
        _skinIndexBought.Clear();
        int amount = PlayerPrefs.GetInt("Amount");
        for(int i = 0; i < amount; i++)
        {
            int SkinIndex = PlayerPrefs.GetInt("SkinIndex" + i);
            _skinIndexBought.Add(SkinIndex);
        }
    }

    private void UpdateStartSkin()
    {
        _currentSkin.SetActive(false);
        _skins[_currentSkinIndex].SetActive(true);
        _currentSkin = _skins[_currentSkinIndex];

    }

    public void UpdateShopButtons()
    {
        _jumpUpgradeCostText.text = Mathf.Ceil(_jumpUpgradeCost).ToString() + " Gems";
        _weaponUpgradeCostText.text = Mathf.Ceil(_weaponUpgradeCost).ToString() + " Gems";
        for (int i = 0; i < _skinIndexBought.Count; i++)
        {
            for (int j = 0; j < _skins.Count; j++)
            {
                if (_skinIndexBought[i] == j)
                {
                    _buyButtons[i].gameObject.SetActive(false);
                    _chooseButton[i].gameObject.SetActive(true);
                }
            }
        }
    }
}
