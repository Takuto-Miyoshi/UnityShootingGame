using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
定期的に上方向に一回転、下方向に一回転を繰り返しながら前に進むAI

*/

public class Enemy03 : MonoBehaviour
{

    float Speed = 0.08f;

    public GameObject ExplosionPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        transform.Translate(-Speed, 0.0f, 0.0f);
        transform.Rotate(0.0f, 0.0f, -5.0f,Space.World);
        transform.Translate(-Speed, 0.0f, 0.0f,Space.World);
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
