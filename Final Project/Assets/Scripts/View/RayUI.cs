using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayUI : MonoBehaviour
{
    public RectTransform UI;//准星
    public Transform gunPos;//枪口位置
    private RaycastHit hit;
    public LayerMask layer;//遮罩层
    public GUIStyle textStyle; // 文本样式，可以在Inspector中调整

    void Start(){
        // GameObject obj = GameObject.Find("CrossBow");
        // gunPos = obj.transform;
        textStyle.normal.textColor = Color.red;
    }
    //Update is called once per frame
    private void Update()
    {
        //物理投放射线（起始位置，方向）
        // if (Physics.Raycast(gunPos.position, gunPos.forward, out hit, 10, layer.value))
        // {
        //     Vector3 gunUI = Camera.main.WorldToScreenPoint(hit.point);
        //     UI.gameObject.SetActive(true);
        //     UI.position = gunUI;

        // }
        // else
        //     UI.gameObject.SetActive(false);
        
    }
    void OnGUI(){
        // 设置文本的位置为屏幕中心
        float centerX = Screen.width / 2;
        float centerY = Screen.height / 2;

        // 绘制文本
        GUI.Label(new Rect(centerX + 10, centerY + 30, 100, 100), "o", textStyle);
    }
}
