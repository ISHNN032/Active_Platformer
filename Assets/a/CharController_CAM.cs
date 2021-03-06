﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class CharController_CAM : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    //앞으로 달리기 및 걷기와 뒷걸음의 속도
    [SerializeField] private float forwardRunSpeed = 7.0f;
    [SerializeField] private float forwardSpeed = 3.0f;
    [SerializeField] private float sideSpeed = 2.0f;
    [SerializeField] private float backwardSpeed = 2.0f;

    //애니매이션 재생속도
    [SerializeField] private float animSpeed = 1.5f;
    
    private CapsuleCollider col;
    private Rigidbody rigib;
    private Animator anim;

    //캐릭터를 움직일 벡터
    private Vector3 velocity;

    //카메라 -> 캐릭터 선회 여부
    private bool C_rotate;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();
        rigib = GetComponent<Rigidbody>();
        C_rotate = true;
    }

    private void FixedUpdate()
    {
        //현재 정의된 입력으로 되어있으나, UI가 나오면 UI로 변경한다
        float input_h = Input.GetAxis("Horizontal");
        float input_v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", input_v);

        //혹시 옆으로만 가고 있을 때에도 애니에 속도를 넣어줘야 해서.(수정예정)
        if(Mathf.Abs(input_v) <= 0.1f)
            anim.SetFloat("Speed", Mathf.Abs(input_h));
        
        anim.SetFloat("Direction", input_h);

        anim.speed = animSpeed;

        //애니매이션 상태 초기화
        anim.SetBool("Run", false);

        #region Move

        velocity = new Vector3(input_h, 0, input_v);
        //다음과 같이 카메라에 맞추어 수정하는 것이 적합하다고 본다

        #region Rotate_Look
        if (C_rotate)
        {
            Vector3 forward = mainCamera.transform.TransformDirection(Vector3.forward);
            forward.y = 0;
            var lookDirection = Quaternion.LookRotation(forward);
            Vector3 euler = new Vector3(0, lookDirection.y, 0);

            transform.rotation = lookDirection;

            //로컬 방향에 맞게 벨로시티를 수정
            velocity = mainCamera.transform.TransformDirection(velocity);
        }
        #endregion Rotate_Look

        //입력에 따라 속도의 변화를 준다
        if (Mathf.Abs(input_v) > 0.1f || Mathf.Abs(input_h) > 0.1f)
        {
            //뒤로 가고 있으면 어찌 되었건 뒤로가는 속도가 나오는 것으로 했다
            if (input_v < -0.1f)
                velocity *= backwardSpeed;

            //만약 옆으로 움직인다면
            else if (Mathf.Abs(input_h) > 0.1f)
            {
                //앞과 옆의 비율을 계산하여 옆속도 ~ 앞속도 만큼 움직인다
                velocity *= Mathf.Lerp(sideSpeed, forwardSpeed, input_v / (1 + Mathf.Abs(input_h)));
            }

            //앞으로만 가고 있다면
            else
            {
                //앞을 향하는 임계에 있을 경우만 달리기를 체크한다
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetBool("Run", true);
                    velocity *= forwardRunSpeed;
                    anim.SetFloat("Speed", input_v * 2);
                }
                else
                    velocity *= forwardSpeed;
            }
        }

        //연산이 끝난 벡터를 로컬포지션에서 더한다
        transform.localPosition += velocity * Time.fixedDeltaTime;

        #endregion Move

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(C_rotate == true)
                SetLookRotate(false);
            else if (C_rotate == false)
                SetLookRotate(true);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag.Equals("Platform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag.Equals("Platform"))
        {
            this.transform.parent = null;
        }
    }


    public void SetLookRotate(bool value)
    {
        C_rotate = value;
    }

    public void Attack()
    {
        if (! anim.GetBool("Attack"))
            StartCoroutine("Attack_Couroutine");
    }

    public IEnumerator Attack_Couroutine()
    {
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("Attack", false);
    }
}
