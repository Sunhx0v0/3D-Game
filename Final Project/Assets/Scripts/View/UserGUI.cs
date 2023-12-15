using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    public int mode;
    public int score;
    public int arrowNum;
    public string gameMessage;
    private IUserAction action;
    public GUIStyle bigStyle, blackStyle, smallStyle;//自定义字体格式
    public Font pixelFont;
    private int menu_width = Screen.width / 5, menu_height = Screen.width / 10;//主菜单每一个按键的宽度和高度
    // Start is called before the first frame update
    void Start()
    {
        mode = 0;
        gameMessage = "";
        action = Director.getInstance().currentSceneController as IUserAction;

        //大字体初始化
        bigStyle = new GUIStyle();
        bigStyle.normal.textColor = Color.black;
        bigStyle.normal.background = null;
        bigStyle.fontSize = 50;
        bigStyle.alignment=TextAnchor.MiddleCenter;

        //black
        blackStyle = new GUIStyle();
        blackStyle.normal.textColor = Color.black;
        blackStyle.normal.background = null;
        blackStyle.fontSize = 50;
        blackStyle.alignment=TextAnchor.MiddleCenter;

        //小字体初始化
        smallStyle = new GUIStyle();
        smallStyle.normal.textColor = Color.black;
        smallStyle.normal.background = null;
        smallStyle.fontSize = 20;
        smallStyle.alignment=TextAnchor.MiddleCenter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI(){
        GUI.skin.button.fontSize = 35;
        GameStart();
    }

    // void mainMenu() {
    //     GUI.Label(new Rect(Screen.width / 2 - menu_width * 0.5f, Screen.height * 0.1f, menu_width, menu_height), "Welcome", bigStyle);
    //     bool button = GUI.Button(new Rect(Screen.width / 2 - menu_width * 0.5f, Screen.height * 3 / 7, menu_width, menu_height), "Start");
    //     if (button) {
    //         mode = 1;
    //     }
    // }

    void GameStart() {
        GUI.Label(new Rect(400, 60, 50, 200), gameMessage, bigStyle);
        GUI.Label(new Rect(0,0,100,50), "得分: " + score, smallStyle);
        GUI.Label(new Rect(0,0,300,50), "剩余箭数: " + arrowNum, smallStyle);
    }
}
