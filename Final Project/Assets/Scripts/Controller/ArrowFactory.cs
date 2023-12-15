using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ArrowFactory : MonoBehaviour
{
    List<GameObject> used;
    List<GameObject> free;
    FirstController scenecontrolller;
    // Start is called before the first frame update
    void Start()
    {
        used = new List<GameObject>();
        free = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetArrow() {
        GameObject arrow;
        if (free.Count != 0) {
            arrow = free[0];
            free.Remove(arrow);
        }
        else {
            arrow = GameObject.Instantiate(Resources.Load("Prefabs/Arrow", typeof(GameObject))) as GameObject;
            arrow.AddComponent<Arrow>();
        }
        scenecontrolller = (FirstController)Director.getInstance().currentSceneController;
        //得到弓箭上搭箭的位置                       
        Transform bow_mid = scenecontrolller.bow.transform.GetChild(4); // 获得箭应该放置的位置
        //将箭的位置设置为弓中间的位置
        arrow.transform.position = bow_mid.transform.position;
        arrow.transform.rotation = bow_mid.transform.rotation;

        arrow.transform.parent = scenecontrolller.bow.transform;
        used.Add(arrow);
        arrow.SetActive(true);
        return arrow;
    }

    public void FreeArrow(GameObject arrow) {
        arrow.SetActive(false);
        if (!used.Contains(arrow)) {
            // throw new MyException("Try to remove a item from a list which doesn't contain it.");
        }
        used.Remove(arrow);
        free.Add(arrow);
    }
}
