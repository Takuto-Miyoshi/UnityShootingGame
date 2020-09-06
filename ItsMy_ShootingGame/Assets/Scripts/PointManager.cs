using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public GameObject PointObject;

    public void PrintPoint(float Point_, float MaxPoint_) {
        Text PointText = PointObject.GetComponent<Text>();
        PointText.text = "" + Point_ + "/" + MaxPoint_;
    }
}
