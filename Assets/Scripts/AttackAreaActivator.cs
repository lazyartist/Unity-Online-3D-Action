﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaActivator : MonoBehaviour {
    //공격 판정 컬라이더 배열
    Collider[] attackAreaColliders;

	void Start () {
        //자식 오브젝트에서 AttackArea 스크립트가 추가된 오브젝트를 찾는다.
        AttackArea[] attackAreas = GetComponentsInChildren<AttackArea>();
        attackAreaColliders = new Collider[attackAreas.Length];
        for (int i = 0; i < attackAreas.Length; i++)
        {
            //AttackArea 스크립트가 추가된 오브젝트의 컬라이더를 배열에 저장한다.
            attackAreaColliders[i] = attackAreas[i].GetComponent<Collider>();
            //초기값은 false로 한다.
            attackAreaColliders[i].enabled = false;
        }
    }
	
    void StartAttackHit()
    {
        //Debug.Log("StartAttackHit in AttackAreaActivator");
        foreach (Collider item in attackAreaColliders)
        {
            item.enabled = true;
        }
    }

    void EndAttackHit()
    {
        //Debug.Log("EndAttackHit in AttackAreaActivator");
        foreach (Collider item in attackAreaColliders)
        {
            item.enabled = false;
        }
    }
}
