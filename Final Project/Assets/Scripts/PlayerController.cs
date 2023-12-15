using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    //获得player的CharacterController组件
    private CharacterController cc;
 
    public float moveSpeed = 80.0f;//移动速度
 
    public float jumpSpeed = 50.0f;//跳跃速度
 
    //定义获得按键值的两个变量
    private float horizontalMove, verticalMove;
 
    //定义三维变量dir控制方向
    private Vector3 dir;
 
    //重力
    private float gravity = 9.8f;
 
    private Vector3 velocity;//用来控制Y轴速度
 
    //我们只需要检测player是否在地上就可以了，这里我们可以使用Physics中的CheckSphere方法，如果定义的球体和物体发生碰撞，返回真
    //为了使用这个方法，我们需要定义几个变量
    public Transform groundCheck;//检测点的中心位置
    public float checkRedius;//检测点的半径
    public LayerMask groundLayer;//需要检测的图层
    //布尔值来存储CheckSphere的返回值
    public bool isGround;
 
 
    private void Start()
    {
        //获取player的CharacterController组件
        cc = GetComponent<CharacterController>();
        //锁定鼠标后再解锁，鼠标将自动回到屏幕中心
        Cursor.lockState = CursorLockMode.Locked;
        // Cursor.lockState = CursorLockMode.None;
        //隐藏鼠标
        Cursor.visible = false;
    }
    private void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position,checkRedius,groundLayer);
        if(isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
 
        horizontalMove = Input.GetAxis("Horizontal") *2 * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * 2 * moveSpeed;
 
        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);
 
        //我们需要获取到跳跃按键的事件，使用Input中的GetButtonDown()方法，他会返回一个布尔值，当按下时才会返回真
        //Jump可以在InputManager中查看
        //在一瞬间有一个向上的速度，在过程中也会随着重力慢慢下降，如果想要让它只跳跃一次的话，加上isGround就行了
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocity.y = jumpSpeed*1.4f;
        }
 
        velocity.y -= gravity * Time.deltaTime;
        //再用CharacterController的Move方法来移动y轴
        cc.Move(velocity * Time.deltaTime);
    }
}