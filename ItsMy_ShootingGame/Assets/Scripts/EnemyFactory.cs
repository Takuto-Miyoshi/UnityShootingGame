using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject firstBoss;

    public int bossSpawnTime;

    int count = 0;
    bool isEnemySpawn = true;

    public enum Wave {
        Cross,
        Sway
    }

    public Wave wave = Wave.Sway;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        wave = Wave.Sway;
    }

    // 1フレームに1回実行 => フレームレートは変わるので実行周期が不安定
    void FixedUpdate() {

        if (!isEnemySpawn) return;

        count++;

        switch (wave) {
            case Wave.Cross:
                if ((count + 60) % 120 == 0) {

                    Instantiate(enemyPrefabs[0], this.transform.position, Quaternion.identity);
                }

                if (count % 120 == 0) {

                    Instantiate(enemyPrefabs[1], this.transform.position, Quaternion.identity);
                }

                if(count >= 600) {
                    count = 0;
                }
                break;

            case Wave.Sway:
                if (count % 60 == 0) {
                    Instantiate(enemyPrefabs[2], this.transform.position, Quaternion.identity);
                }

                if(count >= 300) {
                    count = 0;
                }
                break;

        }
    }
}
