using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingFlatform : ActivePlatform {

    public GameObject[] ob_array;

    protected override void Awake()
    {
        base.Awake();
        ob_array = new GameObject[this.transform.childCount];
        for (int i = 0; i < ob_array.Length; ++i)
            ob_array[i] = this.transform.GetChild(i).gameObject;
    }

    public override void Active()
    {
        StartCoroutine("Movement");
    }
    public override void Deactive()
    {
        StopCoroutine("Movement");
    }

    IEnumerator Movement()
    {
        while (true)
        {
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
            while (ob_array[0].transform.position != targetPos[0])
            {
                for (int i = 0; i < ob_array.Length; ++i)
                {
                    ob_array[i].transform.position = Vector3.Lerp(ob_array[i].transform.position, targetPos[i], 0.2f);
                }
                yield return null;
            }
        }
    }

    protected override void OnCollisionExit(Collision collision){}
    protected override void OnCollisionStay(Collision collision){}
}
