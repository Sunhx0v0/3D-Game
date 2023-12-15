using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{
    public Animator animator;
    public FirstController firstController;
    public float power = 0.4f;
    private bool isHolding = false;
    private bool isMouseDown;
    private bool isMouseLongPressed;

    private float longPressDuration = 0.2f; // 定义长按的持续时间

    void Start(){
        animator = GetComponent<Animator>();
        firstController = (FirstController)Director.getInstance().currentSceneController;
    }

    private void Update()
    {
        // 长按左键不断增加力量
        if (isMouseLongPressed && !isHolding)
        {
            power = Mathf.Min(power + Time.deltaTime, 1f);
        }
        // Debug.Log(power);
        animator.SetFloat("power", power);
        if(firstController.GetArea() && firstController.arrowNum>0){
            ClickCheck();
        }
        
    }

    public void ClickCheck(){
        // 按下左键
        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log("单击左键");
            if(!isHolding){
                isMouseDown = true;
                isMouseLongPressed = false;

                // 开始协程检测长按
                StartCoroutine(CheckLongPress());
                // 触发start
                animator.SetFloat("power", power);
                animator.SetTrigger("start");
            }
            else{
                ShootAnimator();
            }
        }
        else if(isMouseLongPressed && Input.GetMouseButtonDown(1)){//right key down
            // Debug.Log("右键按下");
            isHolding = true;
            // 停止协程
            StopCoroutine(CheckLongPress());
            isMouseLongPressed = false;

            animator.SetFloat("hold power", power);
            animator.SetTrigger("hold");
        }
        // 松开左键
        else if (isMouseDown && Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            if(!isHolding){
                // Debug.Log("松开左键");
                isMouseLongPressed = false;

                // 停止协程
                StopCoroutine(CheckLongPress());
                //触发hold
                animator.SetFloat("hold power", power);
                // Debug.Log("hold power:"+power+".");
                animator.SetTrigger("hold");
                // 触发shoot
                ShootAnimator();
            }
        }
    }

    private IEnumerator CheckLongPress()
    {
        yield return new WaitForSeconds(longPressDuration);
        // 如果鼠标处于按下状态，则表示长按
        if (isMouseDown)
        {
            // Debug.Log("长按左键");
            isMouseLongPressed = true;
        }
        
    }

    private void ShootAnimator(){
        animator.SetTrigger("shoot");
        firstController.ShootCallback(true, power);
        isHolding = false;
        power = 0.4f;        
        // animator.SetFloat("power",power);
        // animator.SetFloat("hold power",power);
    }
    // 其他代码...
}
