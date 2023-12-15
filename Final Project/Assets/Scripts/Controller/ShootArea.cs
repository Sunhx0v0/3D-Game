using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ShootArea : MonoBehaviour
{
    //是否可以射箭
    private bool canShoot;
    public FirstController firstController;

    void Start(){
        firstController = (FirstController)Director.getInstance().currentSceneController;
    }
 
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canShoot = true;
            firstController.AreaCallBack(canShoot);
        }
    }
 
 
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canShoot = false;
            firstController.AreaCallBack(canShoot);
        }
    }
}