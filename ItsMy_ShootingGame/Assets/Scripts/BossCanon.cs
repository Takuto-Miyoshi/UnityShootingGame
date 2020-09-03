using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCanon : MonoBehaviour
    {

    public GameObject player;
    public GameObject bullet;

    const float TIMER_RESET = 0.0f;
    float shootingSpace = 0.5f;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= shootingSpace) {
            RobotAimBullet();
            timer = TIMER_RESET;
        }

    }

    void RobotAimBullet() {
        // 自機に向かって撃つ　追尾はしない　発射から到着までの時間が一定？
        // 参考 : https://aoaoaoaoaoaoaoi.hatenablog.com/entry/2018/10/14/191142

        if (player != null) {
            var pos = this.gameObject.transform.position;
            var t = Instantiate(bullet) as GameObject;

            t.transform.position = pos;

            Vector2 vec = player.transform.position - pos;
            t.GetComponent<Rigidbody2D>().velocity = vec;
        }
    }
}
