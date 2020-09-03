using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet01 : MonoBehaviour {

    float speed = 0.05f;
    float distance = 1.0f;


    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, 2.0f);

    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {

    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Player" ||
            collision.tag == "PlayerBullet") {
            Destroy(gameObject);
        }

    }
}
