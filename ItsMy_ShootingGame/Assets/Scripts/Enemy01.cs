using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{

    float Speed = 0.12f;

    public GameObject ExplosionPrefab = null;

    // Informationに項目追加される
    // Resources.Loadを先にやっておくことと同義

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        transform.Translate(-Speed, 0.0f, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if(collision.tag == "Player" ||
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
