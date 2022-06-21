using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private int _heathPoint;

    public void TakeDamage(int damage)
    {
        _heathPoint -= damage;
    }
}
