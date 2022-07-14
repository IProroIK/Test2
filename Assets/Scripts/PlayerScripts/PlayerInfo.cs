using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private int _heathPoint;
    public int currency { get; private set; }
    public void TakeDamage(int damage)
    {
        _heathPoint -= damage;
    }

    public void AddCurrency(int currency)
    {
        this.currency += currency;
    }
}
