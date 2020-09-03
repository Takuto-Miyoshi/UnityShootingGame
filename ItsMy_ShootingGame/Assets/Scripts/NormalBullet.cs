using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{

    float Speed = 0.24f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        transform.Translate(Speed, 0.0f, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Enemy" || collision.tag == "Boss") {
            Destroy(gameObject);
        }
        
    }
    void OnBecameInvisible() {
        Robot.DecrementBullet();
        Destroy(gameObject);
    }
}
