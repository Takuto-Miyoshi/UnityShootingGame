﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletStraight : MonoBehaviour
{

    float Speed = 0.14f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        transform.Translate(-Speed, 0.0f, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "HitBox") {
            Destroy(gameObject);
        }

    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
