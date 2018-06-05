using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour {
    [SerializeField] public GameObject Camera;
    [SerializeField] public GameObject Text;

    private void OnTriggerEnter(Collider other)
    {
        Camera.SetActive(true);
        Text.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Camera.SetActive(false);
    }
}
