using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update

    // HierarchyのObjectはUnityが管理している
    // Instantiateで複製された時にHierarchyに追加される
    // 追加された時に１回だけ実行されるのが Start
    void Start()
    {
        // Destroyの第二引数 => 指定したオブジェクトが死ぬまでにかかる時間(秒)
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
