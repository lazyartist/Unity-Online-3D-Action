using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public Vector2 slideStartPosition;
    public Vector2 prevPosition;
    public Vector2 deltaPosition = Vector3.zero;
    public bool moved = false;

	void Start () {
		
	}
	
	void Update () {
        //슬라이드 시작지점
        if (Input.GetButtonDown("Fire1"))//Fire1 버튼이 눌린 프레임에서만 true 반환
        {
            slideStartPosition = GetCursorPosition();
        }

        //화면 너비의 10% 이상 커서를 이동시키면 슬라이드 시작으로 판단
        if(Input.GetButton("Fire1"))//Fire1 버튼이 눌려 있는 상태이면 true 반환
        {
            if(Vector2.Distance(slideStartPosition, GetCursorPosition()) >= Screen.width * 0.1f)
            {
                moved = true;
            }
        }

        //슬라이드가 끝났는가
        if(!Input.GetButtonUp("Fire1") && !Input.GetButton("Fire1"))
        {
            moved = false;
        }

        //이동량을 구한다
        if (moved)
        {
            deltaPosition = GetCursorPosition() - prevPosition;
        }
        else
        {
            deltaPosition = Vector2.zero;
        }

        //커서 위치를 갱신
        prevPosition = GetCursorPosition();
	}

    //클릭되었는가
    public bool Clicked()
    {
        if(!moved && Input.GetButtonUp("Fire1"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //슬라이드할 때 커서 이동량
    public Vector2 GetDeltaPosition()
    {
        return deltaPosition;
    }

    //슬라이드 중인가
    public bool Moved()
    {
        return moved;
    }

    public Vector2 GetCursorPosition()
    {
        return Input.mousePosition;//mousePosition는 Vector3
    }
}
