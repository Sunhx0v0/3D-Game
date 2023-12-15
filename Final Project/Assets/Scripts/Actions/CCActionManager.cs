using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, IActionCallback 
{
    public FirstController sceneController;
    public FlyAction action;
    public ArrowFactory factory;

    public GameObject arrow;
    public GameObject crossbow;
    public float forceRate=0.33f;
    
    // Start is called before the first frame update
    protected new void Start()
    {
        sceneController = (FirstController)Director.getInstance().currentSceneController;
        sceneController.actionManager = this;
        factory = Singleton<ArrowFactory>.Instance;
        crossbow = GameObject.Find("Crossbow");
    }

    public void SSActionEvent(SSAction source,
        SSActionEventType events = SSActionEventType.Completed,
        int intParam = 0,
        string strParam = null,
        Object objectParam = null) {
            factory.FreeArrow(source.transform.gameObject);
    }

    public void ShootArrow(float power){
        Quaternion bowRotation = crossbow.transform.rotation;

		arrow = factory.GetArrow();
		Vector3 shootDirection = bowRotation * Vector3.up;
        // Debug.Log(shootDirection);
		arrow.GetComponent<Rigidbody>().AddForce(shootDirection * power * forceRate, ForceMode.Impulse);
        arrow.transform.parent = null;
        action = FlyAction.GetSSAction();
        this.RunAction(arrow, action, this);
    }
}
