using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPoint : MonoBehaviour
{
    GameObject player;

    Robot robot;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Robot");
        robot = player.GetComponent<Robot>();
    }

    void FixedUpdate() {
        transform.Translate(-0.05f, 0.0f, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            robot.point += Random.Range(1, 3);
            Destroy(gameObject);
        }
    }
}
