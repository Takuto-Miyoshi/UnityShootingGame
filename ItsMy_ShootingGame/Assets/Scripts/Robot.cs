using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Robot : MonoBehaviour
{
    // 移動速度
    float Speed = 0.1f;

    // 弾を撃つタイミング
    int shootingTiming = 0;

    // Powerオブジェクト
    public GameObject UiPowerObject;
    public GameObject UiPointObject;

    // 攻撃力
    public int power = 1;
    public int maxPower = 5;

    // ポイント
    public int point = 0;
    public int maxPoint = 100;

    GameObject hitBox;
    HitBox hitbox;

    // Start is called before the first frame update
    void Start()
    {
        hitBox = GameObject.Find("hitbox");
        hitbox = hitBox.GetComponent<HitBox>();
        UiPowerObject.GetComponent<PowerManager>().PrintPower(power, maxPower);
        UiPointObject.GetComponent<PointManager>().PrintPoint(point, maxPoint);
        Vector2 RobotPos = new Vector2(-2.5f, 0.5f);
        this.transform.position = RobotPos;
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        UiPointObject.GetComponent<PointManager>().PrintPoint(point, maxPoint);

        // 射撃
        if (Input.GetKey(KeyCode.Z)) {
            shootingTiming++;
        }
        else {
            shootingTiming = 0;
        }

        if (shootingTiming != 0 && shootingTiming % 4 == 0) {
            GameObject normalBullet = (GameObject)Resources.Load("Prefabs/NormalBullet");

            if (normalBullet != null) {
                Instantiate(normalBullet, transform.position, Quaternion.identity);
            }
        }

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

        // ポイントが溜まっていたらパワーアップ
        if(point >= maxPoint) {
            if (Input.GetKeyDown(KeyCode.A)) {
                point -= 100;
                hitbox.MaxHp += 3;
                hitbox.Hp += 3;
                hitbox.UiHpObject.GetComponent<HpManager>().PrintHp(hitbox.Hp, hitbox.MaxHp);
            }

            if (Input.GetKeyDown(KeyCode.S)) {
                point -= 100;
                power += 1;
                UiPowerObject.GetComponent<PowerManager>().PrintPower(power, maxPower);
            }
        }
    }
}
