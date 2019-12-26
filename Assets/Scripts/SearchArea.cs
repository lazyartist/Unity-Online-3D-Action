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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter " + this.name);
        Debug.Log("OnTriggerEnter " + other.name);
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.tag);
        Debug.Log("OnTriggerStay " + this.name);
        Debug.Log("OnTriggerStay " + other.name);
        //Debug.Log(other.transform.parent.name);
        //Player 태그를 타깃으로 한다
        if (other.CompareTag("Player"))
        {
            enemyCtrl.SetAttackTarget(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit " + this.name);
        Debug.Log("OnTriggerExit " + other.name);
    }
}
