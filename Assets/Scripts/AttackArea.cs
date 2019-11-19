using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour {
    CharacterStatus status;
    new Collider collider;//new : 상속멤버 collider를 명시적으로 숨긴다.

    void Start () {
        status = transform.root.GetComponent<CharacterStatus>();
        collider = GetComponent<Collider>();
    }

    public class AttackInfo
    {
        //공격력
        public int attackPower;
        //공격자
        public Transform attacker;
    }

    AttackInfo GetAttackInfo()
    {
        AttackInfo attackInfo = new AttackInfo();
        //공격력 계산
        attackInfo.attackPower = status.Power;
        attackInfo.attacker = transform.root;//transform.root 계층에서 가장 위에 있는 Transform을 반환(절대 null을 반환하지 않음)

        return attackInfo;
    }

    //맞았다
    private void OnTriggerEnter(Collider other)
    {
        //공격 당한 상대의 Damage 메시지를 보낸다
        other.SendMessage("Damage", GetAttackInfo());
        //공격한 대상을 저장한다.
        status.lastAttackTarget = other.transform.root.gameObject;
    }

    //공격 판정을 유효로 한다.
    void OnAttack()
    {
        collider.enabled = true;
    }

    //공격 판정을 무효로 한다.
    void OnAttackTermination()
    {
        collider.enabled = false;
    }
}
