using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkyBox : MonoBehaviour
{
    public Material[] mats;
    private int index=0;
    // 获取Directional Light组件
    private Light directionalLight;
    public Gradient lightColorGradient;
    public AnimationCurve lightIntensityCurve;

    // Start is called before the first frame update
    void Start()
    {
        mats = Resources.LoadAll<Material>("Materials/skyboxs");
        RenderSettings.skybox = mats[0];
        index ++;
        directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            ChangeBox();
        }
        ChangeLight();
    }
    public void ChangeBox()
    {
        RenderSettings.skybox = mats[index];
        index++;
        index %= mats.Length;
    }
    public void ChangeLight(){
        float currentTime = index*6f;
        // 计算当前的光强度
        float intensity = lightIntensityCurve.Evaluate(currentTime);
        // 计算当前的光颜色
        Color color = lightColorGradient.Evaluate(currentTime / 24f);
        // 设置光源的方向（模拟太阳的移动）
        float rotationAngle = (currentTime - 5f) * 15f; // 每小时15度
        directionalLight.transform.rotation = Quaternion.Euler(rotationAngle, -85f, 0f);

        // 设置光源的强度和颜色
        // directionalLight.intensity = intensity;
        directionalLight.color = color;
    }
}
