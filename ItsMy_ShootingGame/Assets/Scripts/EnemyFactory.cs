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

    public int scallTrigger = 0;

    public enum Wave {
        Cross,
        Sway,
        Around,
        Scall,
        Boss
    }

    public Wave wave = Wave.Sway;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
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

                if(count >= 300) {
                    wave = Wave.Scall;
                    count = 0;
                }
                break;

            case Wave.Sway:
                if (count % 60 == 0) {
                    Instantiate(enemyPrefabs[2], this.transform.position, Quaternion.identity);
                }

                if ((count + 20) % 60 == 0) {
                    Instantiate(enemyPrefabs[2], this.transform.position, Quaternion.identity);
                }

                if ((count + 40) % 60 == 0) {
                    Instantiate(enemyPrefabs[2], this.transform.position, Quaternion.identity);
                }

                if (count >= 150) {
                    wave = Wave.Around;
                    count = 0;
                }
                break;
            case Wave.Around:
                if (count % 60 == 0) {
                    Instantiate(enemyPrefabs[3], this.transform.position, Quaternion.identity);
                    Instantiate(enemyPrefabs[4], this.transform.position, Quaternion.identity);
                }

                if ((count + 10) % 60 == 0) {
                    Instantiate(enemyPrefabs[3], this.transform.position, Quaternion.identity);
                    Instantiate(enemyPrefabs[4], this.transform.position, Quaternion.identity);
                }

                if ((count + 20) % 60 == 0) {
                    Instantiate(enemyPrefabs[3], this.transform.position, Quaternion.identity);
                    Instantiate(enemyPrefabs[4], this.transform.position, Quaternion.identity);
                }

                if (count >= 150) {
                    wave = Wave.Cross;
                    count = 0;
                }
                break;
            case Wave.Scall:

                if (count == 10) {
                    Instantiate(enemyPrefabs[5], this.transform.position, Quaternion.identity);
                }

                if (count == 250) {
                    scallTrigger = 1;
                    Instantiate(enemyPrefabs[5], this.transform.position, Quaternion.identity);
                }

                if(count == 260) {
                    scallTrigger = 2;
                    Instantiate(enemyPrefabs[5], this.transform.position, Quaternion.identity);
                }

                if (count >= 800) {
                    wave = Wave.Boss;
                    count = 0;
                }
                break;
            case Wave.Boss:
                isEnemySpawn = false;
                Instantiate(firstBoss, this.transform.position, Quaternion.identity);
                break;

        }
    }
}
