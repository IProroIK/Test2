using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DeathZone : MonoBehaviour
{
    public event Action OnDeth;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement playerMovement))
        {
            OnDeth?.Invoke();
            SpeshilForKuna.fuckingShit += 1;
        }
    }
}
