using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private int _linerenderLength;
    private void Awake()
    {
        DisableLineRender();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[_linerenderLength];

        _lineRenderer.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = origin + speed * time + (Physics.gravity * time * time / 2f);
        }

        _lineRenderer.SetPositions(points);
    }

    public void DisableLineRender()
    {
        _lineRenderer.gameObject.SetActive(false);
        _lineRenderer.positionCount = 0;
    }

    public void EnableLineRender()
    {
        _lineRenderer.gameObject.SetActive(true);
    }
}
