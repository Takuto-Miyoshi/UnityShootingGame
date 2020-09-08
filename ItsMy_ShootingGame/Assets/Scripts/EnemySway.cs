using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class EnemySway : MonoBehaviour
{

    int hp = 5;

    float speed = 0.1f;
    float createRotationTimer = 0.0f;
    float createRotationTime = 0.0f;
    bool is_Rotate = true;
    int rotate = 45;

    Vector2 enemy1;

    GameObject player;

    Robot robot;

    public GameObject ExplosionPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Robot");
        robot = player.GetComponent<Robot>();
        enemy1 = new Vector2(7.0f, Random.Range(-1.0f, 1.0f));
        this.transform.position = enemy1;
        Destroy(gameObject, 7.0f);
        createRotationTime = 0.0f;
    }

    // Update is called once per frame
    void Update() {
        createRotationTimer += Time.deltaTime;
        if(createRotationTimer >= createRotationTime) {
            is_Rotate = !is_Rotate;
            createRotationTimer = 0.0f;
            createRotationTime = Random.Range(0.5f, 1.0f);

            Vector3 Angle = transform.localEulerAngles;
            if (is_Rotate) {
                Angle.z = rotate;
            }
            else {
                Angle.z = -rotate;
            }
            transform.Rotate(Angle);
            rotate = 90;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(-speed, 0.0f, 0.0f);
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
