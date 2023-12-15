using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAction : SSAction
{
    public GameObject arrow;
    public ArrowFactory arrowFactory;
    public GameObject crossbow;
    public float forceRate=10f;
    public static FlyAction GetSSAction() {
        FlyAction action = ScriptableObject.CreateInstance<FlyAction>();
        return action;
    }
    // Start is called before the first frame update
    public override void Start()
    {
        crossbow = GameObject.Find("CrossBow");
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
}
