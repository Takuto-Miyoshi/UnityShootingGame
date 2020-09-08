using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
定期的に上方向に一回転、下方向に一回転を繰り返しながら前に進むAI

*/

public class EnemyAround : MonoBehaviour
{

    float Speed = 0.05f;

    int hp = 7;

    public GameObject ExplosionPrefab = null;

    GameObject player;

    Robot robot;

    Vector2 enemy1;

    int count = 0;

    // Informationに項目追加される
    // Resources.Loadを先にやっておくことと同義

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Robot");
        robot = player.GetComponent<Robot>();
        enemy1 = new Vector2(7.0f, -1.5f);
        this.transform.position = enemy1;
        Destroy(gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        enemy1 = this.transform.position;
        count++;

        transform.Translate(-Speed, 0.0f, 0.0f);
        if (enemy1.x <= 2.0f) {
            transform.Rotate(0.0f, 0.0f, -1.5f);

        }

        if (count % 15 == 0) {
            GameObject Bullet = (GameObject)Resources.Load("Prefabs/NormalEnemyBullet");

            if (Bullet != null) {
                Instantiate(Bullet, transform.position, transform.rotation);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "HitBox" ||
           collision.tag == "PlayerBullet") {

            hp -= robot.power;

            if (hp <= 0) {

                GameObject Power = (GameObject)Resources.Load("Prefabs/PowerItem");

                if (Power != null && Random.Range(0, 3) != 0) {
                    Instantiate(Power, transform.position, Quaternion.identity);
                }

                Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
