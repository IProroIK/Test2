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
    [SerializeField] private float _maxJumpDistance;
    [SerializeField] private bool _canJump;
    [SerializeField] private bool _stopMoving;

    [SerializeField] private TrajectoryRenderer _trajectoryRenderer;
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Shop _shop;
    private void Awake()
    {
        _stopMoving = true;
        _shop.inShop += StopMove;
        _shop.closeShop += EnebleMove;
    }

    private void OnDisable()
    {
        _shop.inShop -= StopMove;
        _shop.closeShop += EnebleMove;
    }

    private void Update()
    {
        if (_stopMoving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _mousePositionStart = (Input.mousePosition);
                _trajectoryRenderer.EnableLineRender();
            }
            if (Input.GetMouseButton(0))
            {
                _mousePositionEnd = (Input.mousePosition);
                _distance = Distance(_mousePositionStart, _mousePositionEnd);
                if (_distance >= 5f)
                {
                    _forceToZAxics = _distance * 0.02f;
                    if (_distance > _playerInfo.maxJumpDistance)
                    {
                        _forceToZAxics = _playerInfo.maxJumpDistance * 0.02f;
                    }
                    _trajectoryRenderer.ShowTrajectory(new Vector3(0, 0, 0), new Vector3(0, _forceToYAxics, _forceToZAxics));
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                _trajectoryRenderer.DisableLineRender();
                _mousePositionEnd = (Input.mousePosition);
                _distance = Distance(_mousePositionStart, _mousePositionEnd);
                if (_distance >= 50f)
                {
                    _forceToZAxics = _distance * 0.02f;
                    if (_distance > _playerInfo.maxJumpDistance)
                    {
                        _forceToZAxics = _playerInfo.maxJumpDistance * 0.02f;
                    }
                    Jump(_canJump);
                }


            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _canJump = true;
        MoveOnPlatform(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        OutPlatform(collision);
    }

    private void Jump(bool canJump)
    {
        if (canJump == true)
        {
            _rigidbody.AddForce(new Vector3(0, _forceToYAxics, _forceToZAxics), ForceMode.VelocityChange);
            _canJump = false;
        }
    }

    private float Distance(Vector3 firstPoint, Vector3 secondPoint)
    {
        float resualt = Mathf.Sqrt(Mathf.Pow(firstPoint.x - secondPoint.x, 2) + Mathf.Pow(firstPoint.y - secondPoint.y, 2) + Mathf.Pow(firstPoint.z - secondPoint.z, 2));
        return resualt;
    }

    private void MoveOnPlatform(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlatformsMover platformMover))
        {
            transform.parent = collision.transform;
        }
    }

    private void OutPlatform(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlatformsMover platformMover))
        {
            transform.parent = null;
        }
    }

    public void StopMove()
    {
        _stopMoving = false;
        _mousePositionStart = Input.mousePosition;
        _mousePositionEnd = Vector3.zero;
    }

    public void EnebleMove()
    {
        _stopMoving = true;
        _mousePositionStart = Input.mousePosition;
        _mousePositionEnd = Vector3.zero;
    }
}
