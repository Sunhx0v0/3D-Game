using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    //当前环的分值
    public int RingScore ;
    public ISceneController scene;
    public ScoreRecorder sc_recorder;
    // Start is called before the first frame update
    void Start()
    {
        scene = Director.getInstance().currentSceneController as FirstController;
        sc_recorder = Singleton<ScoreRecorder>.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //碰撞检测，如果箭击中该环，就响应。
//     void OnCollisionEnter(Collision collision)
//     {
//         Debug.Log("collison enter");
//         // 得到箭身
//         Transform arrow = collision.gameObject.transform;
//         Debug.Log(arrow);
//         if (arrow == null)
//         {
//             return;
//         }
//         if (arrow.tag == "arrow")
//         {
//             //将箭的速度设为0
//             arrow.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
//             // Debug.Log("击中"+RingScore);
//             //使用运动学运动控制
//             arrow.GetComponent<Rigidbody>().isKinematic = true;
//             arrow.transform.parent = this.transform.parent;         // 将箭和靶子绑定
//             //计分
//             sc_recorder.Record(RingScore);
//             //标记箭为中靶
//             // arrow.tag = "onTarget";
//         }
//     }

    void OnTriggerEnter(Collider collision){
        Debug.Log("trigger");
        Transform arrow = collision.gameObject.transform;
        Debug.Log(arrow);
        if (arrow == null)
        {
            return;
        }
        if (arrow.tag == "arrow")
        {
            //将箭的速度设为0
            arrow.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            // Debug.Log("击中"+RingScore);
            //使用运动学运动控制
            arrow.GetComponent<Rigidbody>().isKinematic = true;
            arrow.transform.parent = this.transform.parent;         // 将箭和靶子绑定
            //计分
            sc_recorder.Record(RingScore);
            //标记箭为中靶
            // arrow.tag = "onTarget";
        }
    }
}