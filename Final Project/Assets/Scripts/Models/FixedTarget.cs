using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTarget : MonoBehaviour
{
    public GameObject fixedTarget;  // 固定靶对象

    // public GameObject movableTarget;    // 移动靶对象
    // public Role[] roles;    //船上的角色
    // public bool isRight;    //用于判断船的位置
    // public int pastorCount, devilCount;
    public FixedTarget(Vector3 position,Quaternion rotation, int scale){
        fixedTarget = GameObject.Instantiate(Resources.Load("Prefabs/Military target", typeof(GameObject))) as GameObject;
        fixedTarget.name = "Military target";
        fixedTarget.transform.position = position;
        fixedTarget.transform.rotation = rotation;
        fixedTarget.transform.localScale = new Vector3(scale, scale, scale);
    }
}
