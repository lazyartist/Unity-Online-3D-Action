using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerGui : MonoBehaviour {
    public GameRuleCtrl gameRuleCtrl;
    public Text TimerText;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimerText.text = gameRuleCtrl.timeRemaining.ToString("##.#");
    }
}
