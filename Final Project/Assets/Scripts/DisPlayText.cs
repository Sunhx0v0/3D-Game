using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    private string[] texts; // 要显示的文本

    private Text displayTextComponent;

    void Start()
    {
        // texts[0] = "5m";
        // texts[1] = "10m";
        // texts[2] = "15m";
        // for(int i=0;i<3;i++){
        //     // 创建并设置文本组件
        //     displayTextComponent = gameObject.AddComponent<Text>();
        //     displayTextComponent.text = texts[i];

        //     // 设置文本属性
        //     displayTextComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); // 使用Arial字体
        //     displayTextComponent.fontSize = 24;
        //     displayTextComponent.color = Color.white;

        //     // 获取目标游戏物体的屏幕位置
        //     Vector3 targetPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        //     // 设置文本的位置
        //     RectTransform rectTransform = displayTextComponent.GetComponent<RectTransform>();
        //     rectTransform.position = targetPosition + new Vector3(0,0.5f*(i+1),0);
        // }
    }
}