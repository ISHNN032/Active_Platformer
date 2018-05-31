using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    //원래의 키 세팅을 저장하는 역할
    [SerializeField] protected KeyCode Org_ActivateKey;
    [SerializeField] protected KeyCode Org_DectivateKey;

    //상태에 따라 바뀌는 동작 키
    protected KeyCode ActivateKey;
    protected KeyCode DeactivateKey;

    protected virtual void Awake()
    {
        InitializeKey();
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(ActivateKey))
        {
            Active();
        }
        else if (Input.GetKeyDown(DeactivateKey))
        {
            Deactive();
        }
    }

    public void InitializeKey()
    {
        ActivateKey = Org_ActivateKey;
        DeactivateKey = Org_DectivateKey;
    }

    public virtual void Active()
    {
        Debug.Log(string.Format("Active{0}", this.gameObject.name));

        InitializeKey();
        ActivateKey = 0;
        //활성화된 플랫폼을 계속 활성화 시켜도 곤란하므로, 키 초기화 전까지 끈다.
    }
    public virtual void Deactive()
    {
        Debug.Log(string.Format("Deactive{0}", this.gameObject.name));

        InitializeKey();
        DeactivateKey = 0;
        //비활성화는 되돌아 가능 등의 움직임이 있으므로 활성화처럼 계속 반복하면 곤란하다.
    }
}
