using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Meteor : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEffectsPrefab;
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _heathPoint = 1;

    private void OnEnable()
    {
        StartCoroutine(KickMeteor());
    }

    public void TakeDamage(int damage)
    {
        _heathPoint -= damage;
        if(_heathPoint <= 0)
        {
            Instantiate(_destroyEffectsPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator KickMeteor()
    {
        _rigidbody.DOMove(_player.position, _speed);
        yield return new WaitForSeconds(_speed);
        _rigidbody.useGravity = true;
    }
}
