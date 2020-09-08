using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_01 : MonoBehaviour
{
    float speed = 0.05f;
    float timer = 0.0f;
    public int hp = 100;
    public GameObject ExplosionPrefab = null;

    public GameObject player;
    public GameObject bullet;

    const float TIMER_RESET = 0.0f;
    float aimShootingSpace = 0.2f;

    Vector2 BossPosion;


    // 敵の行動用 列挙定数
    enum ActionPart {
        Apearance,  // 出現
        Battle,     // 戦闘
        Destroy,    // 死亡
    }

    ActionPart Action = ActionPart.Apearance;
    public float apeaFinishPoint = 3.5f; // 4.5f は止めたい位置

    // Start is called before the first frame update
    void Start()
    {
        BossPosion = new Vector2(7.0f, 0.5f);
        this.transform.position = BossPosion;
        player = GameObject.Find("Robot");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        switch (Action) {
            case ActionPart.Apearance:
                ApearanceAction();
                break;

            case ActionPart.Battle:
                BattleAction();
                break;

            case ActionPart.Destroy:
                DestroyAction();
                break;
        }

    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "PlayerBullet") {
            hp--;

            if (hp <= 0) {
                Action = ActionPart.Destroy;

                GameObject obj = GameObject.Find("GameController");
                if (obj != null) {
                    GameController component = obj.GetComponent<GameController>();
                    if (component != null) {
                        component.ChangeState(GameController.GameState.Cleared);
                    }
                }
            }
        }
    }

    void ApearanceAction() {
        if (transform.position.x <= apeaFinishPoint) {
            Action = ActionPart.Battle;
        }
        transform.Translate(-speed, 0.0f, 0.0f);
    }

    void BattleAction() {
        if (timer >= aimShootingSpace) {
            RobotAimBullet();
            timer = TIMER_RESET;
        }
    }

    void DestroyAction() {
        Destroy(gameObject, 3.0f);

        BossPosion = transform.position;

        BossPosion.x += Random.Range(3.0f, -3.0f);
        BossPosion.y += Random.Range(3.0f, -3.0f);

        if (Random.Range(1, 30) == 1) {
            Instantiate(ExplosionPrefab, BossPosion, Quaternion.identity);
        }
    }
    void RobotAimBullet() {
        // 自機に向かって撃つ　追尾はしない　発射から到着までの時間が一定？
        // 参考 : https://aoaoaoaoaoaoaoi.hatenablog.com/entry/2018/10/14/191142

        if (player != null) {
            var pos = this.gameObject.transform.position;
            var t = Instantiate(bullet) as GameObject;

            t.transform.position = pos;

            Vector2 vec = player.transform.position - pos;
            t.GetComponent<Rigidbody2D>().velocity = vec;
        }
    }
}
