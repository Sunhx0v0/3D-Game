using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{
    int score;
    public FirstController firstController;
    public UserGUI userGUI;
    // Start is called before the first frame update
    void Start()
    {
        firstController = (FirstController)Director.getInstance().currentSceneController;
        firstController.scoreController = this;
        userGUI = this.gameObject.GetComponent<UserGUI>();
    }

    public void Record(int ringscore) {
        score += ringscore;
        userGUI.score = score;
    }
}
