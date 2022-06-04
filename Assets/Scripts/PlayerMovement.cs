using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _mousePositionStart;
    [SerializeField] private Vector3 _mousePositionEnd;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _forceToYAxics;
    [SerializeField] private float _forceToZAxics;
    [SerializeField] private float _distance;
    [SerializeField] private bool _canJump;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePositionStart = Input.mousePosition;

        }
        if (Input.GetMouseButtonUp(0))
        {
            _mousePositionEnd = Input.mousePosition;
            _distance = Distance(_mousePositionStart, _mousePositionEnd);
            _forceToZAxics = _distance;
            Jump(_canJump);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _canJump = true;
    }

    private void Jump(bool canJump)
    {
        if (canJump == true)
        {
            _rigidbody.AddForce(new Vector3(0, _forceToYAxics, _forceToZAxics), ForceMode.Impulse);
            _canJump = false;
        }
    }

    private float Distance(Vector3 firstPoint, Vector3 secondPoint)
    {
        float resualt = Mathf.Sqrt(Mathf.Pow(firstPoint.x - secondPoint.x, 2) + Mathf.Pow(firstPoint.y - secondPoint.y, 2) + Mathf.Pow(firstPoint.z - secondPoint.z, 2));
        return resualt;
    }
}
