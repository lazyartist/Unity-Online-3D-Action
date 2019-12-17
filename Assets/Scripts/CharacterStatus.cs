using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour {
    //체렬
    public int HP = 100;
    public int MaxHp = 100;
    //공격력
    public int Power = 10;
    //공격력 강화
    public bool powerBoost = false;
    //공격력 강화 시간
    public float powerBoostTime = 0.0f;
    //마지막에 공격한 대상
    public GameObject lastAttackTarget = null;
    //플레이어 이름
    public string characterName = "Player";
    //상태
    public bool attacking = false;
    public bool died = false;

    private void Update()
    {
        powerBoost = false;
        if(powerBoostTime > 0.0f)
        {
            powerBoost = true;
            powerBoostTime = Mathf.Max(powerBoostTime - Time.deltaTime, 0.0f);
        }
    }

    //아이템 획득
    public void GetItem(DropItem.ItemKind itemKind)
    {
        switch (itemKind)
        {
            case DropItem.ItemKind.Attack:
                powerBoostTime = 5.0f;
                break;
            case DropItem.ItemKind.Heal:
                //MaxHP의 절반 회복
                HP = Mathf.Min(HP + MaxHp / 2, MaxHp);
                break;
        }
    }
}
