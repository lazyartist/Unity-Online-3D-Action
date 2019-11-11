using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//캐릭터 이동
public class CharacterMove : MonoBehaviour
{
    //중력값
    const float GravityPower = 9.8f;
    //목적지에 도착했다고 보는 정지 거리
    const float StoppingDistance = 1.0f;

    //현재 이동 속도
    Vector3 velocity = Vector3.zero;
    //캐릭터 컨트롤러의 캐시
    CharacterController characterController;
    //도착했는지 여부(true:도착, false:미도착)
    public bool arrived = false;
    //방향을 강제로 지시하는가?
    bool forceRotate = false;
    //강제로 향하게 하고 싶은 방향
    Vector3 forceRotateDirection;
    //목적지
    public Vector3 destination;
    //이동속도
    public float walkSpeed = 6.0f;
    //회전속도
    public float rotationSpeed = 360.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        destination = transform.position;
    }

    void Update()
    {
        //이동속도 velocity를 갱신한다.
        if (characterController.isGrounded)
        {
            //test
            //destination = transform.position + Vector3.forward;
            //수평면에서 이동을 고려하므로 XZ만 다룬다.
            Vector3 destinationXZ = destination;
            //목적지와 현재 위치 높이를 똑같이 한다.
            destinationXZ.y = transform.position.y;

            //목적지까지 거리와 방향을 구한다.
            Vector3 direction = (destinationXZ - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, destinationXZ);

            //현재 속도를 보관
            Vector3 currentVelocity = velocity;

            //목적지에 가까이 왔으면 도착
            if (arrived || distance < StoppingDistance)
            {
                arrived = true;
            }

            //이동속도
            if (arrived)
            {
                velocity = Vector3.zero;
            }
            else
            {
                velocity = direction * walkSpeed;
            }

            //이동속도를 부드럽게 보간 처리
            velocity = Vector3.Lerp(currentVelocity, velocity, Mathf.Min(Time.deltaTime * 2.0f, 1.0f));
            velocity.y = 0;

            if (!forceRotate)
            {
                //이동중이라면 이동하는 방향으로 회전한다
                if (velocity.magnitude > 0.1f && !arrived)
                {
                    Quaternion characterTargetRotation = Quaternion.LookRotation(direction);//지정하는 방향에 대한 회전값을 구하고
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, characterTargetRotation, rotationSpeed * Time.deltaTime);//주어진 최댓값이내에서 목표 회전값까지 회전한 값을 구한다.
                }
            }
            else
            {
                //강제로 방향을 지정한다. (목표 지점을 항상 바라본다.)
                Quaternion characterTargetRotation = Quaternion.LookRotation(forceRotateDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, characterTargetRotation, rotationSpeed * Time.deltaTime);
            }
        }

        //중력
        velocity += Vector3.down * GravityPower * Time.deltaTime;//GravityPower값을 조절하여 Time.deltaTime을 곱하지 않게해도 된다.

        //땅에 닿아 있으면 지면을 꽉 누른다.(지면에 따라 튀어오를 수 있기 때문)
        Vector3 snapGround = Vector3.zero;
        if (characterController.isGrounded)
        {
            snapGround = Vector3.down;
        }

        characterController.Move(velocity * Time.deltaTime + snapGround);

        //도착
        if(characterController.velocity.magnitude < 0.1f)
        {
            arrived = true;
        }

        //강제 방향 변경 해제
        if(forceRotate && Vector3.Dot(transform.forward, forceRotateDirection) > 0.99f)
        {
            forceRotate = false;
        }
    }

    //목적지 설정
    public void SetDestination(Vector3 destination)
    {
        arrived = false;
        this.destination = destination;
    }

    //지정한 방향으로 향한다
    public void SetDirection(Vector3 direction)
    {
        forceRotateDirection = direction;
        forceRotateDirection.y = 0.0f;
        forceRotateDirection.Normalize();
        forceRotate = true;
    }

    //이동을 그만둔다.
    public void StopMove()
    {
        //현재 지점을 목적지로 한다.
        destination = transform.position;
    }

    //목적지에 도착했는지 조사한다.(true:도착, false:미도착)
    public bool Arrived()
    {
        return arrived;
    }
}
