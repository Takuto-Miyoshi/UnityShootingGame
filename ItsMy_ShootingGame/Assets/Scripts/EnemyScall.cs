using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScall : MonoBehaviour
{
    float Speed = 0.06f;

    int hp = 40;

    public GameObject ExplosionPrefab = null;

    GameObject player;

    Robot robot;

    Vector2 enemy1;

    GameObject EnemyFactory;
    EnemyFactory enemyFactory;

    int count = 0;

    // Informationに項目追加される
    // Resources.Loadを先にやっておくことと同義

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Robot");
        robot = player.GetComponent<Robot>();

        EnemyFactory = GameObject.Find("EnemyFactory");
        enemyFactory = EnemyFactory.GetComponent<EnemyFactory>();

        switch (enemyFactory.scallTrigger) {
            case 0:
                enemy1 = new Vector2(7.0f, 0.5f);
                break;
            case 1:
                enemy1 = new Vector2(7.0f, 2.5f);
                break;
            case 2:
                enemy1 = new Vector2(7.0f, -1.5f);
                break;

        }

        this.transform.position = enemy1;
        Destroy(gameObject, 20.0f);
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        enemy1 = this.transform.position;
        count++;

        if(count >= 300 || enemy1.x >= 2.5f) {
            transform.Rotate(0.0f, 0.0f, 0.0f);
            transform.Translate(-Speed, 0.0f, 0.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "HitBox" ||
           collision.tag == "PlayerBullet") {

            hp -= robot.power;

            if (hp <= 0) {

                GameObject Power = (GameObject)Resources.Load("Prefabs/PowerItem");

                if (Power != null) {
                    Instantiate(Power, transform.position, Quaternion.identity);
                    Instantiate(Power, transform.position, Quaternion.identity);
                    Instantiate(Power, transform.position, Quaternion.identity);
                    Instantiate(Power, transform.position, Quaternion.identity);
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
