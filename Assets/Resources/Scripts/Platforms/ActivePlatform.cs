using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlatform : Platform<ActivePlatform>
{
    [SerializeField] private KeyCode Org_ActivateKey;
    [SerializeField] private KeyCode Org_DectivateKey;

    private KeyCode ActivateKey;
    private KeyCode DeactivateKey;

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

    public override void Active()
    {
        Debug.Log(string.Format("Active{0}",this.gameObject.name));
    }
    public override void Deactive()
    {
        Debug.Log(string.Format("Deactive{0}", this.gameObject.name));
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
