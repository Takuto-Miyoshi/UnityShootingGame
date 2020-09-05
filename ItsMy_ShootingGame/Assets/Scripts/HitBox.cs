using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{

    // Hpオブジェクト保存用
    public GameObject UiHpObject;

    // 自機体力
    public int MaxHp = 10;
    public int Hp = 10;

    // 攻撃を食らうかどうか
    bool isTakeDamage = true;
    public float invinciblyTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Hp = MaxHp;
        UiHpObject.GetComponent<HpManager>().PrintHp(Hp, MaxHp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision) {

        if (isTakeDamage == true) {

            StartCoroutine(DelayMethod(invinciblyTime, () => {
                isTakeDamage = true;
            }));

            isTakeDamage = false;

            GameObject prefub = (GameObject)Resources.Load("Prefabs/explosion");

            // void OnTriggerEnter2Dの引数が collision なので collision.tag
            if (collision.tag == "Enemy") {
                // 接触したらダメージを受ける
                Hp--;
            }
            else if (collision.tag == "Boss") {
                Hp -= 2;
            }
            else if (collision.tag == "EnemyBullet") {
                Hp--;
            }

            // Hpが変動したらUIのHpも更新する
            UiHpObject.GetComponent<HpManager>().PrintHp(Hp, MaxHp);

            // 体力が０になったら死ぬ
            if (Hp <= 0) {

                /*
                引数に複製したいGameObjectの指定とHierarchyに配置する座標と角度を設定するパターン
                第三引数の角度 => Quaternion.identityで固定
                                  Quaternionは角度の考え方
                                  Quaternion.identity => 回転しない

                */

                Vector3 postion = transform.position;
                Instantiate(prefub, postion, Quaternion.identity);

                // 外部のオブジェクトのスクリプトの関数を実行する
                // GameControllerオブジェクトのGameControllerスクリプトのChangeStateを実行したい

                // ①　オブジェクトを見つける
                // GameObject.Find => Hierarchy上で探したいオブジェクトの名前を指定すると探してくれる
                // 成功 => オブジェクト情報が返る　失敗 => null
                GameObject obj = GameObject.Find("GameController");
                if (obj != null) {
                    // ②　見つかったオブジェクトからGameControllerスクリプトを取得する
                    GameController component = obj.GetComponent<GameController>();

                    if (component != null) {
                        // ③　見つけたComponentでChangeState関数を実行してゲームの状態をPlayingからFailedに変える
                        component.ChangeState(GameController.GameState.Failed);
                    }
                }

                GameObject player = GameObject.Find("Robot");
                Destroy(player);

            }
        }

    }

    // 〇秒後に処理を行うコルーチン
    // waitTime => 待つ時間(秒)　action => 処理内容
    private IEnumerator DelayMethod(float waitTime, System.Action action) {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
