using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosition : MonoBehaviour
{

    public static Vector3 left_shore = new Vector3(-8, -3, 0);
    public static Vector3 right_shore = new Vector3(8, -3, 0);
    public static Vector3 river = new Vector3(0, -4, 0);
    public static Vector3 left_boat = new Vector3(-2.3f, -2.3f, -0.4f);
    public static Vector3 right_boat = new Vector3(2.4f, -2.3f, -0.4f);

    public static Vector3[] fixedT = new Vector3[]
    {   new Vector3(64.7f,6.1f,54.1f), new Vector3(91f, 6.6f,53.4f),
        new Vector3(64.5f,8.63f,63.2f), new Vector3(89f,9.3f,61.9f)
    };

    public static Quaternion[] fixedTr = new Quaternion[]{
        Quaternion.Euler(-90f,-180f,-20.2f), Quaternion.Euler(-90f,-180f,23.5f),
        Quaternion.Euler(-90f,-180f,-30.38f), Quaternion.Euler(-90f,-180f,20.63f)
    };

    public static Vector3[] moveT = new Vector3[]
    {   new Vector3(-90,7,52), new Vector3(-80,8,55),
        new Vector3(-65,8,53)
    };

    public static Quaternion[] moveTr = new Quaternion[]{
        Quaternion.Euler(-90f,-180f,0), Quaternion.Euler(-90f,-180f,23.5f),
        Quaternion.Euler(-90f,-180f,19.25f)
    };
}
