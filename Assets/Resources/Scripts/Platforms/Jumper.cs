using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("aa");
        Rigidbody rigi = other.GetComponent<Rigidbody>();
        rigi.velocity = Vector3.zero;
        rigi.AddForce(this.transform.right * 10f, ForceMode.VelocityChange);
    }
}
