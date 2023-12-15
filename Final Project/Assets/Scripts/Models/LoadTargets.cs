using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTargets : MonoBehaviour
{
    FixedTarget ftargetmodel;

    public void CreateFixedTarget(Vector3 position,Quaternion rotation ,int scale) {
        if (ftargetmodel != null) {
            Object.Destroy(ftargetmodel.fixedTarget);
        }
        ftargetmodel = new FixedTarget(position, rotation, scale);
    }

    // public void CreateMovableTarget(Vector3 position,Quaternion rotation, int scale) {
    //     if (ftargetmodel != null) {
    //         Object.Destroy(ftargetmodel.fixedTarget);
    //     }
    //     ftargetmodel = new FixedTarget(position, rotation, scale);
    //     // ftargetmodel.boat.GetComponent<Click>().setClickAction(this);
    // }

    public FixedTarget GetFixedTModel() {
        return ftargetmodel;
    }
}
