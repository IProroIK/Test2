using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private int _heathPoint;
    public int currency { get; private set; } = 0;

    public float damage { get; private set; } = 1;
    public float maxJumpDistance { get; private set; } = 1200;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("MaxJumpDistance"))
        {
            LoadData();
        }
        else
        {
            Save();
        }
    }
    public void TakeDamage(int damage)
    {
        _heathPoint -= damage;
    }

    public void AddCurrency(int currency)
    {
        this.currency += currency;
        Save();
    }

    public bool Buy(int cost)
    {
        if(currency >= cost)
        {
            currency -= cost;
            return true;
        }
       return false;
    }

    public void DamageUp(float damageUpValue)
    {
        damage += damageUpValue;
        Save();
    }

    public void MaxJumpDistanceUp(float distanceUpValue)
    {
        maxJumpDistance += distanceUpValue;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Currency", currency);
        PlayerPrefs.SetFloat("Damage", damage);
        PlayerPrefs.SetFloat("MaxJumpDistance", maxJumpDistance);
    }

    private void LoadData()
    {
        currency = PlayerPrefs.GetInt("Currency");
        damage = PlayerPrefs.GetFloat("Damage");
        maxJumpDistance = PlayerPrefs.GetFloat("MaxJumpDistance");
    }

}
