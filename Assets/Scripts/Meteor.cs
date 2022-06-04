using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Meteor : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private void OnEnable()
    {
        transform.DOMove(_player.position, 5f);
    }
}
