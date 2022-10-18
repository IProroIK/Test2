using UnityEngine;
using DG.Tweening;
public class Tutorial : MonoBehaviour
{
    [SerializeField] private Transform _hand;
    [SerializeField] private Transform _turorial;
    [SerializeField] private float _legth = 10;
    [SerializeField] private float _time = 2f;
    private float _timeStopOffset = 0.2f;
    private Sequence _handAnimation;
    private void Start()
    {
        TutorialStart();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(_hand.gameObject);
            Destroy(_turorial.gameObject);
            Destroy(this);
        }
    }

    private void TutorialStart()
    {
        _handAnimation = DOTween.Sequence();
        TweenParams tParms = new TweenParams().SetLoops(-1);

        _handAnimation.Append(_hand.DOLocalMoveY(_hand.localPosition.y + _legth, _time))
    .PrependInterval(_timeStopOffset)
    .Append(_hand.DOLocalMoveY(_hand.localPosition.y, _time))
    .PrependInterval(_timeStopOffset).SetAs(tParms);
    }
}
