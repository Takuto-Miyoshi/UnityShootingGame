using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class Enemy02 : MonoBehaviour
{

    float speed = 0.1f;
    float createRotationTimer = 0.0f;
    float createRotationTime = 0.0f;
    bool is_Rotate = true;
    int rotate = 45;

    public GameObject ExplosionPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
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

        if (collision.tag == "Player" ||
           collision.tag == "PlayerBullet") {

            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            /*
                Destroy => 指定されたものを削除する
                    gameObject => このスクリプトを所持しているオブジェクトの本体
                    gameObjectの削除 = Hierarchyからの削除

                    GameObject と gameObject は別物
            */
            Destroy(gameObject);

        }
    }
}
