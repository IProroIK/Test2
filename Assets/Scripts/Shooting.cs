using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _shootLightEffect;
    private void Awake()
    {
        _shootLightEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShootEffect());
        }
    }

    private IEnumerator ShootEffect()
    {
        _shootLightEffect.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _shootLightEffect.SetActive(false);
    }
}
