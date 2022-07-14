using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currencyAmountText;
    [SerializeField] private List<Crystal> _crystals;
    [SerializeField] private PlayerInfo _playerInfo;
    private void Awake()
    {
        for (int i = 0; i < _crystals.Count; i++)
        {
            _crystals[i].OnCrystalPickedUP += UpdateCurrencyAmount;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _crystals.Count; i++)
        {
            _crystals[i].OnCrystalPickedUP -= UpdateCurrencyAmount;
        }
    }

    private void UpdateCurrencyAmount()
    {
        _currencyAmountText.text = _playerInfo.currency.ToString();
    }
}
