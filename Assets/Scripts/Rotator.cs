using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Transform _rotationObject;
    [SerializeField] private Vector3 _rotationSpeed;

    private void Update()
    {
        _rotationObject.Rotate(_rotationSpeed);
    }
}
