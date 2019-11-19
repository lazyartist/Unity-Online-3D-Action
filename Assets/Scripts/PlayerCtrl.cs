using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    const float RayCastMaxDistance = 100.0f;
    CharacterStatus status;
    CharaAnimation charaAnimation;
    Transform attackTarget;
    InputManager inputManager;
    public float attackRange = 1.5f;

    //스테이트의 종류
    enum State
    {
        Walking, Attacking, Died,
    };

    //현재 스테이트
    State state = State.Attacking;
    //다음 스테이트
    State nextState = State.Walking;

    void Start()
    {
        status = GetComponent<CharacterStatus>();
        charaAnimation = GetComponent<CharaAnimation>();
        inputManager = FindObjectOfType<InputManager>();
    }

    void Update()
    {
        switch (state)
        {
            case State.Walking:
                Walking();
                break;
            case State.Attacking:
                Attacking();
                break;
        }

        if (state != nextState)
        {
            state = nextState;
            switch (state)
            {
                case State.Walking:
                    WalkStart();
                    break;
                case State.Attacking:
                    AttackStart();
                    break;
                case State.Died:
                    Died();
                    break;
            }
        }
    }

    //스테이트를 변경한다
    void ChangeState(State nextState)
    {
        //스테이트가 변경되면 nextState에 다음 스테이트를 보관하고 스테이트별 처리가 끝난 후 현재 스테이트를 갱신
        this.nextState = nextState;
    }

    private void WalkStart()
    {
        StateStartCommon();
    }

    void Walking()
    {
        if (inputManager.Clicked())
        {
            Vector2 clickPos = inputManager.GetCursorPosition();
            //Raycast로 대상물을 조사한다.
            Ray ray = Camera.main.ScreenPointToRay(clickPos);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, RayCastMaxDistance,
                (1 << LayerMask.NameToLayer("Ground")) |
                (1 << LayerMask.NameToLayer("EnemyHit")))
            )
            {
                //지면이 클릭되었다
                if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    SendMessage("SetDestination", hitInfo.point);
                    Debug.Log("SetDestination " + hitInfo.point);
                }

                //적이 클릭되었다
                if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("EnemyHit"))
                {
                    //수평 거리를 체크해서 공격할지 결정한다
                    Vector3 hitPoint = hitInfo.point;
                    hitPoint.y = transform.position.y;
                    float distance = Vector3.Distance(hitPoint, transform.position);
                    if (distance < attackRange)
                    {
                        //공격
                        attackTarget = hitInfo.collider.transform;
                        ChangeState(State.Attacking);
                    }
                    else
                    {
                        SendMessage("SetDestination", hitInfo.point);
                    }
                }
            }
        }
    }

    //공격 스테이트가 시작되기 전에 호출된다.
    private void AttackStart()
    {
        StateStartCommon();
        status.attacking = true;

        //적 방향으로 돌아보게 한다
        Vector3 targetDirection = (attackTarget.position - transform.position).normalized;
        SendMessage("SetDirection", targetDirection);

        //이동을 멈춘다
        SendMessage("StopMove");
    }

    //공격 중 처리
    private void Attacking()
    {
        if (charaAnimation.IsAttacked())
        {
            ChangeState(State.Walking);
        }
    }

    private void Died()
    {
        status.died = true;
    }

    void Damage(AttackArea.AttackInfo attackInfo)
    {
        status.HP -= attackInfo.attackPower;
        if (status.HP <= 0)
        {
            status.HP = 0;
            //체력이 0이므로 사망 스테이트로 전환한다
            ChangeState(State.Died);
        }
    }

    //스테이트가 시작되지 전에 status를 초기화한다
    private void StateStartCommon()
    {
        status.attacking = false;
        status.died = false;
    }
}
