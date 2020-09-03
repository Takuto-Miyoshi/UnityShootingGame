using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    public GameObject HpObject;

    public void PrintHp(int Hp_, int MaxHp_)
    {
        Text HpText = HpObject.GetComponent<Text>();
        HpText.text = "" + Hp_ + "/" + MaxHp_;
    }
}
