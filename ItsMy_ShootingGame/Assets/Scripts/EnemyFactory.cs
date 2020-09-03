using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject firstBoss;
    public int bossSpawnTime;
    public float spawnRateMin = 1.5f;
    public float spawnRateMax = 3.0f;

    float createBoss = 0.0f;
    float createTimer = 0.0f ;
    float createTime = 0.0f;
    bool isEnemySpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        /*
        Unityのランダム
        Random.Range(下限, 上限);
        範囲指定した中でランダムな値を返す
        整数も実数も入れられるが範囲が変わる
        
        floatで指定した場合
            Random.Range(min, max); => maxの値を含む
            Random.Range(0.0f, 10.0f); => 0.0f～10.0fの間の値が返る

        intで指定した場合
            Random.Range(min, max); => maxの値は含まない
            Random.Range(0, 10); => 0～9の間の値が返る

        */
        createTime = Random.Range(spawnRateMin, spawnRateMax);
    }

    // 1フレームに1回実行 => フレームレートは変わるので実行周期が不安定
    void Update() {


        if (!isEnemySpawn) return;


        // 約３秒に１回敵を作る
        createTimer += Time.deltaTime;
        createBoss += Time.deltaTime;

        if (createTimer >= createTime) {
            Vector3 create_pos = transform.position; // 基本はEnemyFactoryの座標を使う

            create_pos.y += Random.Range(-2.0f, 2.0f);

            // 敵を作る
            int drawing = Random.Range(0, enemyPrefabs.Length);

            Instantiate(enemyPrefabs[drawing], create_pos, Quaternion.identity);

            createTimer = 0.0f;
            createTime = Random.Range(spawnRateMin, spawnRateMax);
        }

        if(createBoss >= bossSpawnTime) {
            isEnemySpawn = false;

            Instantiate(firstBoss, transform.position, Quaternion.identity);
        }
    }
}
