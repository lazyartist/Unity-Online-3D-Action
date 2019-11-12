using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour {
    //체렬
    public int HP = 100;
    public int MaxHp = 100;
    //공격력
    public int Power = 10;
    //마지막에 공격한 대상
    public GameObject lastAttackTarget = null;
    //플레이어 이름
    public string characterName = "Player";
    //상태
    public bool attacking = false;
    public bool died = false;

	void Start () {
		
	}
	
	void Update () {
		
	}
}
