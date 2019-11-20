using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchArea : MonoBehaviour
{
    EnemyCtrl enemyCtrl;

    void Start()
    {
        //EnemyCtrl을 미리 준비한다
        enemyCtrl = transform.root.GetComponent<EnemyCtrl>();
    }

    private void OnTriggerStay(Collider other)
    {
        //Player 태그를 타깃으로 한다
        if (other.CompareTag("Player"))
        {
            enemyCtrl.SetAttackTarget(other.transform);
        }
    }
}
