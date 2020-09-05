using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Robot : MonoBehaviour
{
    // 移動速度
    float Speed = 0.1f;

    // 弾を撃つタイミング
    int shootingTiming = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 RobotPos = new Vector2(-2.5f, 0.5f);
        this.transform.position = RobotPos;
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.Z)) {
            shootingTiming++;
        }
        else {
            shootingTiming = 0;
        }

        if (shootingTiming != 0 && shootingTiming % 8 == 0) {
            GameObject normalBullet = (GameObject)Resources.Load("Prefabs/NormalBullet");

            if (normalBullet != null) {
                Instantiate(normalBullet, transform.position, Quaternion.identity);
            }
        }
    }

    void FixedUpdate() {

        // 左Shiftキーが押されている間は減速する
        if (Input.GetKey(KeyCode.LeftShift)) {
            Speed = 0.05f;
        }
        else {
            Speed = 0.1f;
        }

        Vector2 RobotPos = this.transform.position;
        // 上下左右キーで移動する
        if (Input.GetKey(KeyCode.UpArrow) && RobotPos.y <= 3.45f){
            transform.Translate(0.0f, Speed, 0.0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && RobotPos.y >= -2.4f){
            transform.Translate(0.0f, -Speed, 0.0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && RobotPos.x >= -4.5f){
            transform.Translate(-Speed, 0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && RobotPos.x <= 4.5f){
            transform.Translate(Speed, 0.0f, 0.0f);
        }
    }
}
