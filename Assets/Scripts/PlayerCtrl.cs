using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    const float RayCastMaxDistance = 100.0f;
    InputManager inputManager;

    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
    }

    void Update()
    {
        Walking();
    }

    void Walking()
    {
        if (inputManager.Clicked())
        {
            Vector2 clickPos = inputManager.GetCursorPosition();
            //Raycast로 대상물을 조사한다.
            Ray ray = Camera.main.ScreenPointToRay(clickPos);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, RayCastMaxDistance, 1 << LayerMask.NameToLayer("Ground")))
            {
                SendMessage("SetDestination", hitInfo.point);
                Debug.Log("SetDestination " + hitInfo.point);
            }
        }
    }
}
