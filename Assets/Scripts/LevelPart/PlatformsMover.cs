using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformsMover : MonoBehaviour
{
    [SerializeField] private float _moveTime;
    [SerializeField] private float _timeOffcetToMove;
    [SerializeField] private bool _isMovingPlatform;
    [SerializeField] private int _dictanceX;
    [SerializeField] private int _distanceZ;
    [SerializeField] private int _distanceY;
    [SerializeField] private float _timeStartOffset;
    private Sequence platformMoveAnimation;

    private void Awake()
    {
        StartCoroutine(PlatformStartMoving());
    }

    private void PlatformMove(float moveTime, float timeOffset, int distanceX, int distanceZ, int distanceY)
    {
        if(_isMovingPlatform)
        {
            platformMoveAnimation = DOTween.Sequence();
            TweenParams tParms = new TweenParams().SetLoops(-1);

            platformMoveAnimation.Append(transform.DOLocalMove(new Vector3(transform.localPosition.x + distanceX, transform.localPosition.y + distanceY, transform.localPosition.z + distanceZ), moveTime))
                .PrependInterval(timeOffset)
                .Append(transform.DOLocalMove(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), moveTime))
                .PrependInterval(timeOffset).SetAs(tParms);
        }
    }

    private IEnumerator PlatformStartMoving()
    {
        yield return new WaitForSeconds(_timeStartOffset);
        PlatformMove(_moveTime, _timeOffcetToMove, _dictanceX, _distanceZ, _distanceY);
    }
}
