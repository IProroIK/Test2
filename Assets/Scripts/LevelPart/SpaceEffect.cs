using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SpaceEffect : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        transform.DOLocalMoveY(-1f, 2f);
    }

    private void OnCollisionExit(Collision collision)
    {
        transform.DOLocalMoveY(0f, 1f);
    }
}
