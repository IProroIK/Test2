using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _shootLightEffect;
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private PlayerInfo _playerInfo;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _shootLightEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.TryGetComponent(out Meteor meteor))
                {
                    StartCoroutine(ShootEffect());
                    meteor.TakeDamage((int)_playerInfo.damage);
                }
            }
        }
    }

    private IEnumerator ShootEffect()
    {
        _shootSound.Play();
        _shootLightEffect.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _shootLightEffect.SetActive(false);
    }
}
