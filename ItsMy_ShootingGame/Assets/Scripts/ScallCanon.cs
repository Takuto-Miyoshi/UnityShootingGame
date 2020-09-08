using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScallCanon : MonoBehaviour
{
    float Speed = 0.06f;

    int hp = 60;

    int count = 0;

    // Informationに項目追加される
    // Resources.Loadを先にやっておくことと同義

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, 20.0f);
    }

    void FixedUpdate() {
        count++;

        if (count >= 60) {
            transform.Rotate(0.0f, 0.0f, Random.Range(-180.0f, 180.0f));

            GameObject Bullet = (GameObject)Resources.Load("Prefabs/NormalEnemyBullet");

            if (Bullet != null) {
                Instantiate(Bullet, transform.position, transform.rotation);
            }
        }
    }

}
