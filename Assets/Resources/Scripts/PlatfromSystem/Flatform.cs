using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Flatform : MonoBehaviour{
    /*
    [SerializeField] [Range(1, 10)] private float speed;
    [SerializeField] private Color PlatformColor;

    //본 세팅을 저장해둘 키
    [SerializeField] private KeyCode Org_ActivateKey;
    [SerializeField] private KeyCode Org_DectivateKey;

    private KeyCode ActivateKey;
    private KeyCode DeactivateKey;

    private void Awake()
    {
        InitializeKey();
        MeshRenderer m = this.gameObject.GetComponent<MeshRenderer>();
        m.material.color = PlatformColor;
    }

    void Update()
    {
        if (Input.GetKeyDown(ActivateKey))
        {
            StartCoroutine("Active_Flatform");
            StopCoroutine("Deactive_Flatform");
        }
        else if(Input.GetKeyDown(DeactivateKey))
        {
            StartCoroutine("Deactive_Flatform");
            StopCoroutine("Active_Flatform");
        }
    }

    public void InitializeKey()
    {
        ActivateKey = Org_ActivateKey;
        DeactivateKey = Org_DectivateKey;
    }

    IEnumerator Active_Flatform()
    {
        InitializeKey();
        ActivateKey = 0;
        while (transform.position.y < (transform.localScale.y / 2))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Deactive_Flatform()
    {
        InitializeKey();
        DeactivateKey = 0;
        while (transform.position.y > (transform.localScale.y / 2) * -1)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            yield return null;
        }
    }
    */
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            collision.collider.transform.parent = this.transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            collision.collider.transform.parent = this.transform.parent;
        }
    }
}
