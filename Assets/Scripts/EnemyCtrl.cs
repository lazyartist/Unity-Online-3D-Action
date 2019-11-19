using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Damage(AttackArea.AttackInfo attackInfo)
    {
        //status.HP -= attackInfo.attackPower;
        //if (status.HP <= 0)
        //{
        //    status.HP = 0;
        //    //체력이 0이므로 사망 스테이트로 전환한다
        //    ChangeState(State.Died);
        //}
    }
}
