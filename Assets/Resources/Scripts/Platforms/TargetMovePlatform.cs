using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovePlatform : Platform
{
    [SerializeField] [Range(1, 10)] private float Speed_Set;
    public Transform targetTransform;

    private Vector3 target;
    private Vector3 origin;

    private float distance;
    private float moveScale;

    protected override void Awake()
    {
        base.Awake();
        origin = this.transform.position;
        target = targetTransform.position;
        distance = Vector3.Distance(origin, target);
        moveScale = distance / 1000 * Speed_Set;

        targetTransform = null;
    }

    public override void Active()
    {
        base.Active();
        StopCoroutine("Deactive_Flatform");
        StartCoroutine("Active_Flatform");
    }
    public override void Deactive()
    {
        base.Deactive();
        StopCoroutine("Active_Flatform");
        StartCoroutine("Deactive_Flatform");
    }

    IEnumerator Active_Flatform()
    {
        float i = 0;
        while (transform.position != target)
        {
            transform.position = Vector3.Lerp(origin, target, i);
            i += moveScale;
            yield return null;
        }
        Debug.Log("On_target");
    }

    IEnumerator Deactive_Flatform()
    {
        float i = 0;
        while (transform.position != origin)
        {
            transform.position = Vector3.Lerp(target, origin, i);
            i += moveScale;
            yield return null;
        }
        Debug.Log("On_origin");
    }
}
