using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Robot");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(target.transform.position);
    }
}
