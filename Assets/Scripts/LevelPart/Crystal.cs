using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Crystal : MonoBehaviour
{
    [SerializeField] private int _crystalValue;
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private AudioSource _pickUPSound;
    [SerializeField] private MeshRenderer _mesh;
    public event Action OnCrystalPickedUP;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerInfo playerInfo))
        {
            
            _playerInfo.AddCurrency(_crystalValue);
            OnCrystalPickedUP?.Invoke();
            _mesh.enabled = false;
            _pickUPSound.Play();
            Destroy(gameObject, 1f);
        }
    }
}
