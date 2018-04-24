using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPlatform : Platform<EmptyPlatform>
{
    public override void Active()
    {
        base.Active();
    }

    public override void Deactive()
    {
        base.Deactive();
    }

    protected override void OnCollisionExit(Collision collision)
    {
        base.OnCollisionExit(collision);
    }

    protected override void OnCollisionStay(Collision collision)
    {
        base.OnCollisionStay(collision);
    }
}
