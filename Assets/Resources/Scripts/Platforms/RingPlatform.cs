using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPlatform : Platform {

    public GameObject[] ob_array;
    public bool stop;

    protected override void Awake()
    {
        base.Awake();
        ob_array = new GameObject[this.transform.childCount];
        for (int i = 0; i < ob_array.Length; ++i)
            ob_array[i] = this.transform.GetChild(i).gameObject;
    }

    public override void Active()
    {
        base.Active();
        StartCoroutine("Movement");
    }
    public override void Deactive()
    {
        base.Deactive();
        stop = true;
        //움직임 단위를 수행중인 중간에 멈추면 문제가 생기기 때문에
        //플레그를 이용해서 반복을 중지시키는 형태로 구현했다.
    }

    IEnumerator Movement()
    {
        while (! stop)
        {
            //Array상 다음 Index의 플랫폼 위치를 목표로 설정한다.
            Vector3[] targetPos = new Vector3[ob_array.Length];
            for (int i = 0; i < ob_array.Length; ++i)
            {
                if (i == ob_array.Length - 1)
                {
                    targetPos[i] = ob_array[0].transform.position;
                }
                else
                {
                    targetPos[i] = ob_array[i + 1].transform.position;
                }
            }

            //목표지점까지 이동시킨다.
            while (ob_array[0].transform.position != targetPos[0])
            {
                for (int i = 0; i < ob_array.Length; ++i)
                {
                    ob_array[i].transform.position = Vector3.Lerp(ob_array[i].transform.position, targetPos[i], 0.2f);
                }
                yield return null;
            }
        }
        stop = false;
    }
}
