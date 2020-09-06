using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{
    public GameObject PowerObject;
    public void PrintPower(float Power_, float MaxPower_) {
        Text PowerText = PowerObject.GetComponent<Text>();
        PowerText.text = "" + Power_ + "/" + MaxPower_;
    }
}
