using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchArea : MonoBehaviour
{
    EnemyCtrl enemyCtrl;

    void Awake()
    {
        //EnemyCtrl을 미리 준비한다
        enemyCtrl = transform.root.GetComponent<EnemyCtrl>();
    }

    void Start()
    {
        //이 게임오브젝트가 활성되되기도 전에 OnTriggerStay가 호출되는 경우가 있으므로 Awake내로 옮김.
        //EnemyCtrl을 미리 준비한다
        //enemyCtrl = transform.root.GetComponent<EnemyCtrl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter " + this.name);
        //Debug.Log("OnTriggerEnter " + other.name);
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("OnTriggerStay " + this.name);
        //Debug.Log("OnTriggerStay " + other.name);
        //Player 태그를 타깃으로 한다
        if (other.CompareTag("Player"))
        {
            enemyCtrl.SetAttackTarget(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("OnTriggerExit " + this.name);
        //Debug.Log("OnTriggerExit " + other.name);
    }
}
