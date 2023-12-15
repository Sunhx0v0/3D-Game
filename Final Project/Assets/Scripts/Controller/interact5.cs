using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact5 : MonoBehaviour
{
    GameObject target;  //需要移动的游戏对象
    Vector3 origin_position;
    Transform origin_transform;
    // Start is called before the first frame update
    void Start()
    {
        origin_position = new Vector3(75f,8f,55f);
        target = GameObject.Find("move-fixed");
        // origin_transform = target.transform;
        // Debug.Log(origin_transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {        
        // 获取被碰撞的物体
        GameObject collidedObject = collision.gameObject;
        if(collidedObject.tag == "arrow"){
            // Debug.Log(origin_transform.position);
            target.transform.position = origin_position;
        }
    }
}
