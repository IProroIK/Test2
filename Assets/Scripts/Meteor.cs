using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Meteor : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _forceDirection;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _rigidbody.DOMove(_player.position, 1f);
    }
}
