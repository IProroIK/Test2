using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformsMover : MonoBehaviour
{
    [SerializeField] private float _moveTime;
    [SerializeField] private float _distance;
    [SerializeField] private float _timeOffcetToMove;
    private Sequence platformMoveAnimation;

    private void Awake()
    {
        PlatformMove(_moveTime, _distance, _timeOffcetToMove);
    }

    private void PlatformMove(float moveTime, float _distance, float timeOffset)
    {
        platformMoveAnimation = DOTween.Sequence();
        TweenParams tParms = new TweenParams().SetLoops(-1);

        platformMoveAnimation.Append(transform.DOMoveX(_distance, moveTime))
            .PrependInterval(timeOffset)
            .Append(transform.DOLocalMoveX(_distance * -1, moveTime))
            .PrependInterval(timeOffset).SetAs(tParms);
    }
}
