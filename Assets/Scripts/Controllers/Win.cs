using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public event Action OnGetToPlanet;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out PlayerMovement player))
        {
            OnGetToPlanet.Invoke();
        }
    }
}
