using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _shootLightEffect;
    [SerializeField] private int _damage = 1;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _shootLightEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.yellow);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit ))
            {
                if(hit.transform.TryGetComponent(out Meteor meteor))
                {
                    StartCoroutine(ShootEffect());
                    meteor.TakeDamage(_damage);
                }
            }
        }
    }

    private IEnumerator ShootEffect()
    {
        _shootLightEffect.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _shootLightEffect.SetActive(false);
    }
}
