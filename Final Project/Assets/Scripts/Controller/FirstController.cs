using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction
{
    public CCActionManager actionManager;
    public ArrowFactory factory;
    public UserGUI userGUI;
    public GameObject bow;
    public ScoreRecorder scoreController;
    public LoadTargets[] loadTargets;
    float shotpower = 0.4f;
    bool shot = false;
    public int arrowNum = 10;
    bool inArea = false;

    void Awake() {
        Director director = Director.getInstance();
        bow = GameObject.Find("Crossbow");

        director.currentSceneController = this;
        director.currentSceneController.LoadSource();

        gameObject.AddComponent<UserGUI>();
        gameObject.AddComponent<CCActionManager>();
        gameObject.AddComponent<ScoreRecorder>();
        gameObject.AddComponent<ArrowFactory>();
        
        factory = Singleton<ArrowFactory>.Instance;
        userGUI = gameObject.GetComponent<UserGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inArea && arrowNum > 0 ){
            Shoot(shotpower);
        }
        userGUI.arrowNum = arrowNum;
    }

    public void LoadSource(){
        loadTargets = new LoadTargets[4];
        for (int i = 0; i < 4; ++i)
        {
            int scale=50;
            if(i==2)
                scale = 80;
            else if(i==3)
                scale = 70;
            loadTargets[i] = new LoadTargets();
            loadTargets[i].CreateFixedTarget(ObjectPosition.fixedT[i],ObjectPosition.fixedTr[i],scale);
        }
    }

    public void Shoot(float shootpower){
        if(shot){
            actionManager.ShootArrow(shootpower);
            shot = false;
            arrowNum --;            
        }
    }

    public void gameOver(){

    }

    public void ShootCallback(bool isShot, float power)
    {
        shotpower = power;
        shot = isShot;
    }

    public void AreaCallBack(bool inArea){
        this.inArea = inArea;
        if(inArea)
            arrowNum = 10;
    }

    public bool GetArea(){
        return inArea;
    }
}
