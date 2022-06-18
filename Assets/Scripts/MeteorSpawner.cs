using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _meteors;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            for (int i = 0; i < _meteors.Count; i++)
            {
                _meteors[i].SetActive(true);
            }
        }
    }
}
