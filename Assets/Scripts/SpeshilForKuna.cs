using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpeshilForKuna : MonoBehaviour
{
    [SerializeField] private bool Kunalevel;
    [SerializeField] private TextMeshProUGUI Kunatext;
    public static int fuckingShit;
    private void Awake()
    {
        if(Kunalevel)
        {
            Kunatext.text += fuckingShit.ToString();
        }
    }
}
