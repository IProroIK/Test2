
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private void Awake()
    {
        GameObject sound = GameObject.FindGameObjectWithTag("BackGroundMusic");
        if(sound != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = "BackGroundMusic";
            DontDestroyOnLoad(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
