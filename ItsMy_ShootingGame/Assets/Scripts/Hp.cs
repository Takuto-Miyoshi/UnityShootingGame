using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public GameObject[] HpImages;

    public void UpdateHpImage(int new_hp) {
        for (int i = 0; i < HpImages.Length; i++) {
            bool is_active = false;
            if (i < new_hp) {
                is_active = true;
            }
            HpImages[i].SetActive(is_active);
        }
    }

    // 危険な方法　ロボットが死んだかわからない => 存在しないメモリにアクセス
    /*

    GameObject RobotObject;

    private void Start() {
        RobotObject = GameObject.Find("Robot");
    }

    private void Update() {
        // 毎フレームRobotオブジェクトのHpを取得してHpを更新
        UpdateHpImage(RobotObject.GetComponent<Robot>().Hp);
    }

    */

}
